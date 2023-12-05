using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace deepcheesebacon.SourceCode.ApprovalSystem.Models
{
    public class Approval
    {
        public int Id { get; set; } // 결재 활동 식별자
        public int RequestId { get; set; } // 결재 요청 식별자
        public int ApproverId { get; set; } // 승인자 식별자
        public int FirstApproverId { get; set; } // 1차 승인자 식별자
        public int SecondApproverId { get; set; } // 2차 승인자 식별자
        public DateTime ApprovalDate { get; set; } // 결재 일자
        public string Title { get; set; } // 결재 제목
        public string Description { get; set; } // 결제 요청 내용
        public string Comment { get; set; } // 결재 의견
        public string RelatedTask { get; set; } // 관련 업무
        public ApprovalStatus Status { get; set; } // 결재 상태

        public Role RoleStatus { get; set; } // 권한 상태

        public string Memo { get; set; } // 반려 시 메모

        public override string ToString()
        {
            return $"결재 제목: {Title}";
        }




        public enum ApprovalStatus
        {
            Pending, // 보류 중
            Approved, // 승인됨
            Rejected // 반려됨
        }

        public class Builder
        {
            private Approval approval = new Approval();

            public Builder RequestId(int requestId)
            {
                approval.RequestId = requestId;
                return this;
            }

            public Builder ApproverId(int approverId)
            {
                approval.ApproverId = approverId;
                return this;
            }

            public Builder FirstApproverId(int firstApproverId)
            {
                approval.FirstApproverId = firstApproverId;
                return this;
            }

            public Builder SecondApproverId(int secondApproverId)
            {
                approval.SecondApproverId = secondApproverId;
                return this;
            }

            public Builder ApprovalDate(DateTime approvalDate)
            {
                approval.ApprovalDate = approvalDate;
                return this;
            }

            public Builder Title(string title)
            {
                approval.Title = title;
                return this;
            }

            public Builder Description(string description)
            {
                approval.Description = description;
                return this;
            }

            public Builder Comments(string comments)
            {
                approval.Comment = comments;
                return this;
            }

            public Builder Status(ApprovalStatus status)
            {
                approval.Status = status;
                return this;
            }

            public Builder RoleStatus(Role roleStatus)
            {
                approval.RoleStatus = roleStatus;
                return this;
            }

            public Builder RelatedTask(string relatedTask)
            {
                approval.RelatedTask = relatedTask;
                return this;
            }
            public Approval Build()
            {
                return approval;
            }
        }
    }

}
