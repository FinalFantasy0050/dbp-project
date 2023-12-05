using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using deepcheesebacon.SourceCode.ApprovalSystem.Models;
using deepcheesebacon;
using Microsoft.Extensions.Logging;
using NLog;


namespace deepcheesebacon
{
    public class ApprovalService
    {
        private object reqeust;
        DBManager dB;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ApprovalService()
        {
            dB = DBManager.GetInstance();
            LoginedUserInfo loginUser = LoginedUserInfo.GetMyInfo();

        }
        public int CreateApproval(Approval request)
        {
            // 결재 요청을 데이터베이스에 저장 후 저장된 Approval 식별자 반환 
            return dB.SaveOrUpdateApproval(request);
        }

        public int ApproveRequest(ApprovalApproveRequest request)
        {
            if (request.approval != null)
            {
                // 승인 상태로 수정

                // 권한 상태 수정 1, 2차 승인자 식별자 등록
                switch (request.approval.RoleStatus)
                {
                    case Role.Requester:
                        request.approval.RoleStatus = Role.FirstApprover;
                        break;
                    case Role.FirstApprover:
                        request.approval.RoleStatus = Role.SecondApprover;
                        request.approval.FirstApproverId = request.approval.ApproverId;
                        request.approval.ApproverId = 4; // 테스트 2차 승인자 한 명이라고 가정하고 4번 대입
                        break;
                    case Role.SecondApprover:
                        request.approval.RoleStatus = Role.Approved;
                        request.approval.SecondApproverId = request.approval.ApproverId;
                        // 최종 승인상태로 수정
                        request.approval.Status = Approval.ApprovalStatus.Approved;

                        break;
                }

                // 결재 시간 업데이트
                request.approval.ApprovalDate = DateTime.Now;
                Console.WriteLine("now time: " + DateTime.Now.ToString());

                int savedApprovalId = dB.SaveOrUpdateApproval(request.approval);
                Console.WriteLine("savedApprovalId: " + savedApprovalId);
                return savedApprovalId;
            }
            return -1;
        }

        public void RejectRequest(ApprovalRejectRequest request)
        {
            Approval approval = dB.GetApprovalById(request.ApprovalId);
            if (approval != null)
            {
                // 승인 상태로 수정
                approval.Status = Approval.ApprovalStatus.Rejected;

                // 권한 상태 수정 // 승인자 수정
                switch (approval.RoleStatus)
                {

                    case Role.FirstApprover:
                        approval.RoleStatus = Role.Requester;
                        approval.ApproverId = approval.RequestId;

                        break;
                    case Role.SecondApprover:
                        approval.RoleStatus = Role.FirstApprover;
                        approval.ApproverId = approval.FirstApproverId;

                        break;
                }


                // 반려 시 메모 사항 저장
                approval.Memo = request.Memo;
                Console.WriteLine("reject approval memo: " + approval.Memo + "approver id: " + approval.ApproverId );

                dB.SaveOrUpdateApproval(approval);
            }
        }

        // 내가 결재해야할 리스트 불러오기
        public List<Approval> GetPendingApprovals(PendingApprovalRequest request)
        {
            return dB.GetPendingApprovalsByUserId(request.userId);
        }

        // 결재 중 내역 불러오기 
        public List<Approval> GetFirstApproverIsMe(PendingApprovalRequest request)
        {
            return dB.GetFirstApproverIsMeByUserId(request.userId);
        }

        // 결재 완료된 내역 불러오기
        public List<Approval> GetCompletedApprovals(PendingApprovalRequest request)
        {
            return dB.GetCompletedApprovalsByUserId(request.userId);
        }

        // 결제 해야될 업무 리스트 불러오기
        public List<string> GetPendingApprovalsRelatedTask(PendingApprovalRequest request)
        {
            List<Approval> approvals = dB.GetPendingApprovalsByUserId(request.userId);
            List<string> relatedTasks = new List<string>();

            foreach (Approval approval in approvals)
            {
                relatedTasks.Add(approval.RelatedTask);
            }

            return relatedTasks;
        }


        // 1차 승인자 userID 리스트 불러오기
        public List<(int, string)> GetFirstApproverIdList()
        {
            return dB.GetFirstApproverIdsList();
        }

        public List<Approval> GetMyApproval(MyApprovalProgressRequest request)
        {
            return dB.GetAllApprovalsByUserId(request.userId);
        }

        internal void LoadDataGridViewApprovalList(DataGridView dataGridViewApprovalList)
        {
            dB.LoadDataGridViewApprovalList(dataGridViewApprovalList);

        }

        internal void LoadDataGridViewTaskSummary(DataGridView dataGridViewTaskSummary)
        {
            dB.LoadDataGridViewTaskSummary(dataGridViewTaskSummary);
        }
    }

}
