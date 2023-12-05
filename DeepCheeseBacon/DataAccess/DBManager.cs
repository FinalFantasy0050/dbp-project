using deepcheesebacon.LoginSystem.Models;
using deepcheesebacon.SourceCode.ApprovalSystem.Models;
using deepcheesebacon.SourceCode.MessageSystem.Models;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace deepcheesebacon
{
    public class DBManager
    {
        private static DBManager dB = new DBManager();
        MySqlConnection connection;
        LoginedUserInfo myInfo = LoginedUserInfo.GetMyInfo();

        private DBManager()
        {
            InitializeConnection();
        }

        public static DBManager GetInstance()
        {
            return dB;
        }
        public int SaveOrUpdateApproval(Approval approval)
        {
            try
            {
                // 데이터베이스에 approvals 테이블이 존재하지 않으면 테이블 생성
                if (!IsApprovalTableExists())
                {
                    CreateApprovalTableIfNotExists();
                }

                // 검색할 쿼리를 작성하여 해당 approval의 유무를 확인
                string searchQuery = "SELECT COUNT(*) FROM approval WHERE Id = @id";
                int existingId = 0;

                using (MySqlCommand searchCmd = new MySqlCommand(searchQuery, connection))
                {
                    searchCmd.Parameters.AddWithValue("@id", approval.Id);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    object searchResult = searchCmd.ExecuteScalar();

                    if (searchResult != null)
                    {
                        existingId = Convert.ToInt32(searchResult);
                    }
                }

                if (existingId > 0)
                {
                    // approval가 이미 존재하므로 업데이트 수행
                    string updateQuery = "UPDATE approval SET request_id = @request_id, approver_id = @approver_id, first_approver_id = @first_approver_id, second_approver_id = @seconde_approver_id,approval_date = @approval_date, title = @title, description = @description, comments = @comments, status = @status, role_status = @role_status, memo = @memo, related_task = @related_task WHERE Id = @id";

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@id", approval.Id);
                        updateCmd.Parameters.AddWithValue("@request_id", approval.RequestId);
                        updateCmd.Parameters.AddWithValue("@approver_id", approval.ApproverId);
                        updateCmd.Parameters.AddWithValue("@first_approver_id", approval.FirstApproverId);
                        updateCmd.Parameters.AddWithValue("@seconde_approver_id", approval.SecondApproverId);
                        updateCmd.Parameters.AddWithValue("@approval_date", approval.ApprovalDate);
                        updateCmd.Parameters.AddWithValue("@title", approval.Title);
                        updateCmd.Parameters.AddWithValue("@description", approval.Description);
                        updateCmd.Parameters.AddWithValue("@comments", approval.Comment);
                        updateCmd.Parameters.AddWithValue("@status", approval.Status);
                        updateCmd.Parameters.AddWithValue("@role_status", approval.RoleStatus);
                        updateCmd.Parameters.AddWithValue("@memo", approval.Memo);
                        updateCmd.Parameters.AddWithValue("@related_task", approval.RelatedTask);

                        updateCmd.ExecuteNonQuery();
                    }

                    return approval.Id;
                }
                else
                {
                    // approval가 존재하지 않으므로 새로 삽입
                    string insertQuery = "INSERT INTO approval (request_id, approver_id, approval_date, title, description, comments, status, role_status, related_task) VALUES (@request_id, @approver_id, @approval_date, @title, @description, @comments, @status, @role_status, @related_task); SELECT LAST_INSERT_ID();";
                    int insertedId = 0;

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@request_id", approval.RequestId);
                        insertCmd.Parameters.AddWithValue("@approver_id", approval.ApproverId);
                        insertCmd.Parameters.AddWithValue("@approval_date", approval.ApprovalDate);
                        insertCmd.Parameters.AddWithValue("@title", approval.Title);
                        insertCmd.Parameters.AddWithValue("@description", approval.Description);
                        insertCmd.Parameters.AddWithValue("@comments", approval.Comment);
                        insertCmd.Parameters.AddWithValue("@status", approval.Status);
                        insertCmd.Parameters.AddWithValue("@role_status", approval.RoleStatus);
                        insertCmd.Parameters.AddWithValue("@memo", approval.Memo);
                        insertCmd.Parameters.AddWithValue("@related_task", approval.RelatedTask);

                        object insertResult = insertCmd.ExecuteScalar();

                        if (insertResult != null)
                        {
                            insertedId = Convert.ToInt32(insertResult);
                        }
                    }

                    return insertedId;
                }
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1; // 예외 발생 시 -1 반환 또는 다른 적절한 처리
            }
        }

        private bool IsApprovalTableExists()
        {
            string checkTableQuery = "SELECT 1 FROM approval LIMIT 1";

            using (MySqlCommand checkCmd = new MySqlCommand(checkTableQuery, connection))
            {
                try
                {

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    checkCmd.ExecuteScalar();
                    return true; // 테이블이 존재함
                }
                catch (MySqlException)
                {
                    return false; // 테이블이 존재하지 않음
                }
            }
        }

        private void CreateApprovalTableIfNotExists()
        {
            string createTableQuery = @"
CREATE TABLE IF NOT EXISTS approval (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    request_id INT DEFAULT 0, -- request_id의 기본값을 0으로 설정
    approver_id INT DEFAULT 0, -- approver_id의 기본값을 0으로 설정
    first_approver_id INT DEFAULT 0, -- first_approver_id의 기본값을 0으로 설정
    second_approver_id INT DEFAULT 0, -- second_approver_id의 기본값을 0으로 설정
    approval_date DATETIME DEFAULT '2023-01-01 00:00:00', -- approval_date의 기본값을 '2023-01-01 00:00:00'으로 설정
    title VARCHAR(255) DEFAULT '', -- title의 기본값을 빈 문자열로 설정
    description TEXT DEFAULT '', -- description의 기본값을 빈 문자열로 설정
    comments TEXT DEFAULT '', -- comments의 기본값을 빈 문자열로 설정
    status INT DEFAULT 0, -- status의 기본값을 0으로 설정
    role_status INT DEFAULT 1, -- role_status의 기본값을 1로 설정
    related_task VARCHAR(255) DEFAULT '' -- related_task의 기본값을 빈 문자열로 설정
) CHARSET=utf8;";

            using (MySqlCommand createCmd = new MySqlCommand(createTableQuery, connection))
            {

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                createCmd.ExecuteNonQuery();
            }
        }



        public Approval GetApprovalById(int approvalId)
        {
            try
            {
                string query = "SELECT * FROM approval WHERE Id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", approvalId);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 데이터베이스에서 가져온 열을 사용하여 Approval 객체 생성
                            Approval approval = new Approval
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                RequestId = reader.GetInt32(reader.GetOrdinal("request_id")),
                                ApproverId = reader.GetInt32(reader.GetOrdinal("approver_id")),
                                FirstApproverId = reader.GetInt32(reader.GetOrdinal("first_approver_id")),
                                SecondApproverId = reader.GetInt32(reader.GetOrdinal("second_approver_id")),
                                ApprovalDate = reader.GetDateTime(reader.GetOrdinal("approval_date")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Comment = reader.GetString(reader.GetOrdinal("comments")),
                                Status = (Approval.ApprovalStatus)reader.GetInt32(reader.GetOrdinal("status")),
                                RoleStatus = (Role)reader.GetInt32(reader.GetOrdinal("role_status")), // RoleStatus가 데이터베이스 스키마에 없다면 주석 처리
                                Memo = reader.GetString(reader.GetOrdinal("memo")),
                                RelatedTask = reader.GetString(reader.GetOrdinal("related_task")),
                            };

                            return approval;
                        }
                    }
                }

                // 데이터를 찾지 못한 경우 null 반환
                return null;
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }

        private void InitializeConnection()
        {
            try
            {
                string connectionString = "Server=34.64.40.193;Database=deep_cheese;Uid=root;Pwd=4564;Charset=utf8";

                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred while initializing connection: {ex.Message}");
                throw; // 예외를 다시 throw하여 호출자에게 전달
            }
        }
        // 내가 등록한 결재 검색
        public List<Approval> GetAllApprovalsByUserId(int userId)
        {
            List<Approval> approvals = new List<Approval>();


            try
            {
                // 유저 ID를 사용하여 해당 유저에 관련된 모든 결재를 검색
                string query = "SELECT * FROM approval WHERE request_id = @userId";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 데이터베이스에서 가져온 열을 사용하여 Approval 객체 생성
                            Approval approval = new Approval
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                RequestId = reader.GetInt32(reader.GetOrdinal("request_id")),
                                ApproverId = reader.GetInt32(reader.GetOrdinal("approver_id")),
                                FirstApproverId = reader.GetInt32(reader.GetOrdinal("first_approver_id")),
                                SecondApproverId = reader.GetInt32(reader.GetOrdinal("second_approver_id")),
                                ApprovalDate = reader.GetDateTime(reader.GetOrdinal("approval_date")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Comment = reader.GetString(reader.GetOrdinal("comments")),
                                Status = (Approval.ApprovalStatus)reader.GetInt32(reader.GetOrdinal("status")),
                                RoleStatus = (Role)reader.GetInt32(reader.GetOrdinal("role_status")),
                                Memo = reader.GetString(reader.GetOrdinal("memo")),
                                RelatedTask = reader.GetString(reader.GetOrdinal("related_task")),
                            };

                            approvals.Add(approval);
                        }
                    }
                }

                return approvals;
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred in GetAllApprovalsByUserId: {ex.Message}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }

        public List<Approval> GetPendingApprovalsByUserId(int userId)
        {
            List<Approval> pendingApprovals = new List<Approval>();

            try
            {
                // 유저 ID를 사용하여 해당 유저에 관련된 "결재 중"인 결재를 검색
                string query = "SELECT * FROM approval WHERE approver_id = @userId AND status = @status AND role_status = @userRole";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@status", (int)Approval.ApprovalStatus.Pending);
                    cmd.Parameters.AddWithValue("@userRole", (int)myInfo.role);


                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 데이터베이스에서 가져온 열을 사용하여 Approval 객체 생성
                            Approval approval = new Approval
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                RequestId = reader.GetInt32(reader.GetOrdinal("request_id")),
                                ApproverId = reader.GetInt32(reader.GetOrdinal("approver_id")),
                                FirstApproverId = reader.GetInt32(reader.GetOrdinal("first_approver_id")),
                                SecondApproverId = reader.GetInt32(reader.GetOrdinal("second_approver_id")),
                                ApprovalDate = reader.GetDateTime(reader.GetOrdinal("approval_date")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Comment = reader.GetString(reader.GetOrdinal("comments")),
                                Status = (Approval.ApprovalStatus)reader.GetInt32(reader.GetOrdinal("status")),
                                RoleStatus = (Role)reader.GetInt32(reader.GetOrdinal("role_status")),
                                Memo = reader.GetString(reader.GetOrdinal("memo")),
                                RelatedTask = reader.GetString(reader.GetOrdinal("related_task")),
                            };

                            pendingApprovals.Add(approval);
                        }
                    }
                }

                return pendingApprovals;
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred in GetPendingApprovalsByUserId: {ex.Message}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }

        /// <summary>
        /// 1차 승인자가 자신인 결재를 불러오는 함수
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Approval> GetFirstApproverIsMeByUserId(int userId)
        {
            List<Approval> pendingApprovals = new List<Approval>();

            try
            {
                // 유저 ID를 사용하여 해당 유저에 관련된 "결재 중"인 결재를 검색
                string query = "SELECT * FROM approval WHERE first_approver_id = @userId AND status = @status";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@status", (int)Approval.ApprovalStatus.Pending); // 결재 중인 상태

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 데이터베이스에서 가져온 열을 사용하여 Approval 객체 생성
                            Approval approval = new Approval
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                RequestId = reader.GetInt32(reader.GetOrdinal("request_id")),
                                ApproverId = reader.GetInt32(reader.GetOrdinal("approver_id")),
                                FirstApproverId = reader.GetInt32(reader.GetOrdinal("first_approver_id")),
                                SecondApproverId = reader.GetInt32(reader.GetOrdinal("second_approver_id")),
                                ApprovalDate = reader.GetDateTime(reader.GetOrdinal("approval_date")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Comment = reader.GetString(reader.GetOrdinal("comments")),
                                Status = (Approval.ApprovalStatus)reader.GetInt32(reader.GetOrdinal("status")),
                                RoleStatus = (Role)reader.GetInt32(reader.GetOrdinal("role_status")),
                                Memo = reader.GetString(reader.GetOrdinal("memo")),
                                RelatedTask = reader.GetString(reader.GetOrdinal("related_task")),
                            };

                            pendingApprovals.Add(approval);
                        }
                    }
                }

                return pendingApprovals;
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred in GetFirstApproverIsMeByUserId: {ex.Message}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }

        public List<Approval> GetCompletedApprovalsByUserId(int userId)
        {
            List<Approval> completedApprovals = new List<Approval>();

            try
            {
                // 유저 ID를 사용하여 해당 유저에 관련된 "결재 완료"된 결재를 검색
                string query = "SELECT * FROM approval WHERE (first_approver_id = @userId OR second_approver_id = @userId) AND status = @status";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@status", (int)Approval.ApprovalStatus.Approved); // 결재 완료 상태

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 데이터베이스에서 가져온 열을 사용하여 Approval 객체 생성
                            Approval approval = new Approval
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                RequestId = reader.GetInt32(reader.GetOrdinal("request_id")),
                                ApproverId = reader.GetInt32(reader.GetOrdinal("approver_id")),
                                FirstApproverId = reader.GetInt32(reader.GetOrdinal("first_approver_id")),
                                SecondApproverId = reader.GetInt32(reader.GetOrdinal("second_approver_id")),
                                ApprovalDate = reader.GetDateTime(reader.GetOrdinal("approval_date")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Comment = reader.GetString(reader.GetOrdinal("comments")),
                                Status = (Approval.ApprovalStatus)reader.GetInt32(reader.GetOrdinal("status")),
                                RoleStatus = (Role)reader.GetInt32(reader.GetOrdinal("role_status")),
                                Memo = reader.GetString(reader.GetOrdinal("memo")),
                                RelatedTask = reader.GetString(reader.GetOrdinal("related_task")),
                            };

                            completedApprovals.Add(approval);
                        }
                    }
                }

                return completedApprovals;
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred in GetCompletedApprovalsByUserId: {ex.Message}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }

        public List<(int, string)> GetFirstApproverIdsList()
        {
            List<(int, string)> firstApproverIdList = new List<(int, string)>();

            try
            {
                string query = "SELECT user_id, email FROM user WHERE user_role = @userRole";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userRole", ((int)LoginedUserInfo.loginedUserInfo.role) + 1);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            firstApproverIdList.Add((reader.GetInt32(reader.GetOrdinal("user_id")), reader.GetString(reader.GetOrdinal("email"))));
                        }
                    }
                }

                return firstApproverIdList;
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred in GetFirstApproverIdsList: {ex.Message}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }


        public User GetUserByEmail(string email)
        {
            try
            {
                string query = "SELECT * FROM user WHERE email = @email";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 데이터베이스에서 가져온 열을 사용하여 User 객체 생성
                            User user = new User
                            {
                                UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                Password = reader.GetString(reader.GetOrdinal("password")),
                                UserRole = (Role)reader.GetInt32(reader.GetOrdinal("user_role")),
                            };

                            return user;
                        }
                    }
                }

                return null; // 값을 찾지 못한 경우 null 반환
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred in GetUserByEmail: {ex.Message}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }

        internal List<string> GetChattingListByUserId(int userId)
        {
            try
            {
                string query = "SELECT email FROM user WHERE user_id != @userId";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    List<string> chattingList = new List<string>();

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chattingList.Add(reader.GetString(reader.GetOrdinal("email")));
                        }
                    }

                    return chattingList;
                }
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred in GetChattingListByUserId: {ex}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }


        private void InitializeDataGridView(DataGridView dataGridView)
        {
            // DataSource를 null로 설정하여 DataGridView의 데이터를 지웁니다.
            dataGridView.DataSource = null;

            // DataGridView의 컬럼들을 지웁니다.
            dataGridView.Columns.Clear();
        }


        // 진행 중인 결재 목록에 들어갈 데이터 불러오기
        internal void LoadDataGridViewApprovalList(DataGridView dataGridViewApprovalList)
        {
            string query = "SELECT title, " +
                           "CASE " +
                           "   WHEN status = 0 THEN '보류 중' " +
                           "   WHEN status = 1 THEN '승인됨' " +
                           "   WHEN status = 2 THEN '반려됨' " +
                           "   ELSE '알 수 없음' " +
                           "END AS status, " +
                           "memo " +
                           "FROM approval " +
                           "WHERE request_id = @myId";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@myId", myInfo.userId);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dt.Columns["status"].ColumnName = "결재 상태";
                        dt.Columns["title"].ColumnName = "결재 제목";
                        dt.Columns["memo"].ColumnName = "반려 메모";

                        InitializeDataGridView(dataGridViewApprovalList);
                        dataGridViewApprovalList.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in LoadDataGridViewApprovalList: {ex.Message}");
                // 추가적인 예외 처리 또는 사용자에게 알림 등을 수행할 수 있습니다.
            }
        }

        internal void LoadDataGridViewTaskSummary(DataGridView dataGridViewTaskSummary)
        {
            string query = "SELECT " +
                "(SELECT COUNT(*) FROM approval WHERE status = 0 AND request_id = @myId) AS count_pending_approval, " +
                "(SELECT COUNT(*) FROM approval WHERE status = 1 AND request_id = @myId) AS count_approved_approval, " +
                "(SELECT COUNT(*) FROM approval WHERE status = 2 AND request_id = @myId) AS count_rejected_approval ";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@myId", myInfo.userId);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dt.Columns["count_pending_approval"].ColumnName = "결재진행 중인 건 수";
                        dt.Columns["count_approved_approval"].ColumnName = "결재승인된 건 수";
                        dt.Columns["count_rejected_approval"].ColumnName = "결재 반려된 건 수";

                        InitializeDataGridView(dataGridViewTaskSummary);
                        dataGridViewTaskSummary.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in LoadDataGridViewTaskSummary: {ex.Message}");
                // 추가적인 예외 처리 또는 사용자에게 알림 등을 수행할 수 있습니다.
            }
        }

        internal List<Message> GetMessagesByEmail(string email, string opponentUserEmail)
        {
            List<Message> messages = new List<Message>();

            string query = "SELECT * FROM message " +
                           "WHERE (sender_id = @senderId AND receiver_id = @receiverId) " +
                           "   OR (sender_id = @receiverId AND receiver_id = @senderId) " +
                           "ORDER BY sent_at";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@senderId", GetUserIdByEmail(email));
                    cmd.Parameters.AddWithValue("@receiverId", GetUserIdByEmail(opponentUserEmail));
                    Console.WriteLine($"getting message / senderID: {GetUserIdByEmail(email)} / receiverid: {GetUserIdByEmail(opponentUserEmail)} ");

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message message = new Message
                            {
                                senderId = reader.GetInt32("sender_id"),
                                receiverId = reader.GetInt32("receiver_id"),
                                content = reader.GetString("content"),
                                sentAt = reader.GetDateTime("sent_at")
                            };

                            messages.Add(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetMessagesByEmail: {ex.Message}");
                // 추가적인 예외 처리 또는 사용자에게 알림 등을 수행할 수 있습니다.
            }

            return messages;
        }

        // 이메일로부터 사용자 ID를 가져오는 보조 함수
        private int GetUserIdByEmail(string email)
        {
            string query = "SELECT user_id FROM user WHERE email = @email";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting user ID: " + ex.Message);
            }

            return -1; // 실패한 경우 -1을 반환하거나 예외 처리 방식을 조정할 수 있습니다.
        }

        internal bool SaveMessage(Message message)
        {
            string query = "INSERT INTO message (sender_id, receiver_id, content, sent_at, title) " +
                            "VALUES (@senderId, @receiverId, @content, @sentAt, @title)";

            string alertQuery = "INSERT INTO alert (user_id) " +
                        "VALUES (@receiverId)";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@senderId", message.senderId);
                    cmd.Parameters.AddWithValue("@receiverId", message.receiverId);
                    cmd.Parameters.AddWithValue("@content", message.content);
                    cmd.Parameters.AddWithValue("@sentAt", message.sentAt);
                    cmd.Parameters.AddWithValue("@title", message.title);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();

                    }
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if(rowsAffected != 0)
                    {
                        // 메시지 저장 성공하면 알람 테이블에도 저장
                        using (MySqlCommand alertCommand = new MySqlCommand(alertQuery, connection))
                        {
                            alertCommand.Parameters.AddWithValue("@userId", message.receiverId); // 여기서는 수신자의 ID를 사용하도록 가정
                            alertCommand.Parameters.AddWithValue("@messageContent", message.content);
                            alertCommand.Parameters.AddWithValue("@receivedAt", DateTime.Now);

                            int rowsAffectedAlert = alertCommand.ExecuteNonQuery();

                            if(rowsAffectedAlert != 0)
                            {
                                Console.WriteLine("알림 등록 성공");
                            }
                            else
                            {
                                Console.WriteLine("알림 등록 실패");

                            }
                        }
                    }

                    // 저장이 성공적으로 이루어졌으면 rowsAffected는 1 이상이 됩니다.
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // 예외 처리: 저장 중에 오류가 발생한 경우
                Console.WriteLine("Error saving message: " + ex.Message);
                return false;
            }
        }

        internal List<Message> GetMessagesById(int userId, int opponentUserId)
        {
            List<Message> messages = new List<Message>();

            string query = "SELECT * FROM message " +
                            "WHERE (sender_id = @userId AND receiver_id = @opponentUserId) " +
                            "   OR (sender_id = @opponentUserId AND receiver_id = @userId) ";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@opponentUserId", opponentUserId);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message message = new Message
                            {
                                senderId = reader.GetInt32("sender_id"),
                                receiverId = reader.GetInt32("receiver_id"),
                                content = reader.GetString("content"),
                                sentAt = reader.GetDateTime("sent_at"),
                                isChecked = reader.GetBoolean("isChecked") // isChecked 값을 추가
                            };

                            if(message.receiverId == LoginedUserInfo.loginedUserInfo.userId)
                            {
                                message.isChecked = true;
                            }

                            messages.Add(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting messages: " + ex.Message);
            }

            return messages;
        }

        public void InsertInfo(int resultNum, string email, string pw, string name, string gender, string pnum, string addr, int id, string date)
        {
            try
            {
                string query = "INSERT INTO user (user_role, email, password, name, gender, phone_number, address, department, birthDate) VALUES (@role, @email, @pw, @name, @gender, @pnum, @addr, @dep, @date)";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@role", resultNum);
                com.Parameters.AddWithValue("@email", email);
                com.Parameters.AddWithValue("@pw", pw);
                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@gender", gender);
                com.Parameters.AddWithValue("@pnum", pnum);
                com.Parameters.AddWithValue("@addr", addr);
                com.Parameters.AddWithValue("@dep", id);
                com.Parameters.AddWithValue("@date", date);

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
        }

        // db에서 department 테이블의 id 값 가져오기
        public int GetDepId(string depid)
        {
            int id = -1;

            try
            {

                string query = "SELECT id FROM department WHERE department_name = @dep_name";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@dep_name", depid);

                // ExecuteScalar를 사용하여 결과를 가져옴
                object objResult = com.ExecuteScalar();

                if (objResult != null && objResult != DBNull.Value)
                {
                    id = Convert.ToInt32(objResult);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }

            return id;
        }

        // db에서 user 테이블의 user_id 값 가져오기
        public int GetUserId(string email)
        {
            int userid = -1;

            try
            {

                string query = "SELECT user_id FROM user WHERE email = @email";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@email", email);

                // ExecuteScalar를 사용하여 결과를 가져옴
                object objResult = com.ExecuteScalar();

                if (objResult != null && objResult != DBNull.Value)
                {
                    userid = Convert.ToInt32(objResult);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }

            return userid;
        }


        public string Email(string id)
        {
            string email = null;
            try
            {

                string query = "SELECT email FROM user WHERE user_id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null)
                {
                    if (email != null)
                    {
                        email = result.ToString();
                    }

                }

                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return email;
        }


        private string MaskString(string original)
        {
            int length = original.Length;
            // 길이만큼 * 로 바꿈
            string maskedString = new string('*', length);

            return maskedString;
        }

        public string Pw(string id)
        {
            try
            {

                string query = "SELECT password FROM user WHERE user_id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // 데이터베이스에서 가져온 값에 대해 마스킹 적용
                    return MaskString(result.ToString());
                }

                return string.Empty; // 데이터가 없을 경우 빈 문자열 반환 또는 다른 기본값 설정

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
                return string.Empty; // 오류 발생 시 빈 문자열 반환 또는 다른 기본값 설정
            }
        }


        public string Name(string id)
        {
            string name = null;
            try
            {

                string query = "SELECT name FROM user WHERE user_id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null)
                {
                    if (name != null)
                    {
                        name = result.ToString();

                    }

                }

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return name;
        }

        public string Date(string id)
        {
            string date = null;
            try
            {

                string query = "SELECT DATE_FORMAT(birthDate,'%Y-%m-%d') FROM user WHERE user_id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null)
                {
                    if (date != null)
                    {
                        date = result.ToString();
                    }

                }

                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return date;
        }

        public string Gender(string id)
        {
            string gender = null;
            try
            {

                string query = "SELECT gender FROM user WHERE user_id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null)
                {
                    gender = result.ToString();
                }

                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return gender;
        }

        public string Role(string id)
        {
            string role = null;
            try
            {

                string query = "SELECT user_role FROM user WHERE user_id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null)
                {
                    if (role != null)
                    {
                        if ((int)result == 0)
                        {
                            role = "원장";
                        }
                        else if ((int)result == 1)
                        {
                            role = "강사";
                        }
                        else if ((int)result == 2)
                        {
                            role = "보조강사";
                        }
                    }


                }

                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return role;
        }

        public string Dep(string id)
        {
            string dep = null;
            try
            {

                string query = "SELECT department_name FROM department WHERE id IN (SELECT department FROM user WHERE user_id = @id)";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null)
                {
                    if (dep != null)
                    {
                        dep = result.ToString();
                    }

                }

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return dep;
        }
        public string Pnum(string id)
        {
            string pnum = null;
            try
            {

                string query = "SELECT phone_number FROM user WHERE user_id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null)
                {
                    pnum = result.ToString();
                }

                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return pnum;
        }

        public string Addr(string id)
        {
            string addr = null;
            try
            {

                string query = "SELECT address FROM user WHERE user_id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);

                object result = com.ExecuteScalar();

                if (result != null)
                {
                    addr = result.ToString();
                }

                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return addr;
        }

        // 콤보박스에 가져올 값 list에 넣음
        public List<string> GetDepartment()
        {
            List<string> departmentList = new List<string>();
            try
            {
                string query = "SELECT * FROM department";
                MySqlCommand com = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string dName = reader["department_name"].ToString();
                        departmentList.Add(dName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
            return departmentList;
        }



        // 유저 관리에서 검색 버튼 누를 경우 (부서별 검색)
        public DataSet GetUser_dep(string dep)
        {
            DataSet ds = new DataSet();

            string query = "SELECT * FROM user WHERE department IN (SELECT id FROM department WHERE department_name like @dep)";
            MySqlCommand com = new MySqlCommand(query, connection);
            com.Parameters.AddWithValue("@dep", "%" + dep + "%");

            using (MySqlDataAdapter da = new MySqlDataAdapter(com))
            {
                // 쿼리 결과를 dt에 넣기
                da.Fill(ds);
            }
            return ds;

        }


        // 사원 관리에서 검색 버튼 누를 경우 (이름별 검색)
        public DataSet GetUser_name(string name)
        {
            DataSet ds = new DataSet();

            string query = "SELECT * FROM user WHERE name like @name";
            MySqlCommand com = new MySqlCommand(query, connection);
            com.Parameters.AddWithValue("@name", "%" + name + "%");

            using (MySqlDataAdapter da = new MySqlDataAdapter(com))
            {
                // 쿼리 결과를 dt에 넣기
                da.Fill(ds);
            }
            return ds;

        }
        public DataSet GetUser_date(string year)
        {
            DataSet ds = new DataSet();

            try
            {

                string query = "SELECT * FROM user WHERE TIMESTAMPDIFF(YEAR, birthDate, CURDATE()) = @year";

                using (MySqlCommand com = new MySqlCommand(query, connection))
                {
                    com.Parameters.AddWithValue("@year", year);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(com))
                    {
                        // 쿼리 결과를 데이터셋에 넣기
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                // 예외 처리: 예외 정보를 로그로 남기고 사용자에게 메시지 표시
                Console.WriteLine("GetUser_date 오류발생: " + e.Message);
                MessageBox.Show("GetUser_date 오류발생: " + e.Message);
            }

            return ds;
        }
        // 부서관리에서 입력하는 학년과 과목이 db에 있는지 확인
        public bool DepartCheck(string grade, string dep)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM department WHERE grade = @grade AND department_name = @dep";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@grade", grade);
                com.Parameters.AddWithValue("@dep", dep);

                int result = Convert.ToInt32(com.ExecuteScalar());

                com.ExecuteNonQuery();

                return result > 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
                return false;
            }

        }

        // 과목관리 등록 누를 경우
        public void DepartInsert(string dep_id, string grade, string dep)
        {
            try
            {
                string query = "INSERT INTO department (department_id, grade, department_name) VALUES (@dep_id, @grade, @dep)";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@dep_id", dep_id);
                com.Parameters.AddWithValue("@grade", grade);
                com.Parameters.AddWithValue("@dep", dep);

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }

        }

        // 과목 관리 수정 누를 경우
        public void DepartModify(string id, string dep_id, string grade, string dep)
        {
            try
            {
                string query = "UPDATE department SET department_id = @dep_id, grade = @grade, department_name = @dep WHERE id = @id";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@dep_id", dep_id);
                com.Parameters.AddWithValue("@grade", grade);
                com.Parameters.AddWithValue("@dep", dep);

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
        }

        // department_id 값의 마지막 숫자 가져오기
        public int Department_IdCheck(string pre_grade, string pre_dep)
        {
            int result = -1;
            try
            {
                string query = "SELECT substring(department_id, 3, 1)  FROM department WHERE grade = @grade AND department_name = @dep";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@grade", pre_grade);
                com.Parameters.AddWithValue("@dep", pre_dep);

                object objresult = com.ExecuteScalar();

                if (objresult != null)
                {
                    result = Convert.ToInt32(objresult);
                }

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);

            }
            return result;
        }

        // department_id 값의 마지막 숫자 중 가장 큰 수 가져오기
        public int Department_IdMaxCheck()
        {
            int maxId = -1;

            try
            {
                string query = "SELECT MAX(substring(department_id, 3, 1)) FROM department";
                MySqlCommand com = new MySqlCommand(query, connection);

                // ExecuteScalar를 사용하여 결과를 가져옴
                object objResult = com.ExecuteScalar();

                if (objResult != null && objResult != DBNull.Value) // 결과가 null이 아니면 변환하여 저장
                {
                    maxId = Convert.ToInt32(objResult);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }

            return maxId; // 결과 반환
        }

        // 과목 관리 삭제 누를 경우 
        public void DepartDelete(string grade, string dep)
        {
            try
            {
                string query = "DELETE FROM department WHERE grade = @grade AND department_name = @dep";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@grade", grade);
                com.Parameters.AddWithValue("@dep", dep);

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
        }


        // 부서 테이블 datagridview에 출력
        public DataSet ViewTable()
        {
            DataSet ds = new DataSet();

            try
            {

                string query = "SELECT * FROM department";

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, connection))
                {
                    da.Fill(ds);
                }

                return ds;
            }
            catch (Exception e)
            {
                // 예외 처리: 예외 정보를 로그로 남기고 사용자에게 메시지 표시
                Console.WriteLine("ViewTable 오류발생: " + e.Message);
                MessageBox.Show("ViewTable 오류발생: " + e.Message);

                return ds; // 빈 DataSet 반환 또는 필요에 따라 null 반환
            }
        }


        // user 테이블 datagridview에 출력
        public DataSet ViewTableUser()
        {
            DataSet ds = new DataSet();

            try
            {
                connection.Open();

                string query = "SELECT * FROM user";

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, connection))
                {
                    da.Fill(ds, "UserTable"); // "UserTable"은 DataTable의 이름입니다.
                }

                return ds;
            }
            catch (Exception e)
            {
                // 예외 처리: 예외 정보를 로그로 남기고 사용자에게 메시지 표시
                Console.WriteLine("ViewTableUser 오류발생: " + e.Message);
                MessageBox.Show("ViewTableUser 오류발생: " + e.Message);

                return ds; // 빈 DataSet 반환 또는 필요에 따라 null 반환
            }

        }

        public DataSet ViewTableAttend(int userid)
        {
            DataSet ds = new DataSet();


            string query = "SELECT attendDate, check_in_time, check_out_time FROM AttendanceLog WHERE user_id = @id ";
            MySqlCommand com = new MySqlCommand(query, connection);
            com.Parameters.AddWithValue("@id", userid);

            using (MySqlDataAdapter da = new MySqlDataAdapter(com))
            {
                da.Fill(ds);
            }

            return ds;

        }

        // 사원 수정에서 수정버튼 누를 경우 
        public void UserModify(int role, string email, string pw, string name, string gender, string pnum, string addr, int id, string date)
        {
            try
            {
                string query = "UPDATE user SET user_role = @role, password = @pw, name = @name, gender = @gender, phone_number = @pnum, address = @addr, department = @dep, birthDate = @date WHERE email = @email";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@role", role);
                com.Parameters.AddWithValue("@email", email);
                com.Parameters.AddWithValue("@pw", pw);
                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@gender", gender);
                com.Parameters.AddWithValue("@pnum", pnum);
                com.Parameters.AddWithValue("@addr", addr);
                com.Parameters.AddWithValue("@dep", id);
                com.Parameters.AddWithValue("@date", date);

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
        }

        public void UserDeleteData(string deleteUserId)
        {
            try
            {

                // SQL 쿼리문
                string query = "DELETE FROM user WHERE user_id = @deleteUserId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // 매개변수 추가
                    command.Parameters.AddWithValue("@deleteUserId", deleteUserId);

                    // 쿼리 실행
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                // 예외 처리: 예외 정보를 로그로 남기고 사용자에게 메시지 표시
                Console.WriteLine("UserDeleteData 오류발생: " + e.Message);
                MessageBox.Show("UserDeleteData 오류발생: " + e.Message);
            }
        }


        // 출근 버튼 누를경우 attendace_log 테이블에 출근시간까지 데이터 넣기
        public void GoWorkInsert(int userid, string date, string intime)
        {
            try
            {
                string query = "INSERT INTO AttendanceLog(user_id, attendDate, check_in_time) VALUES (@userid, @date, @in_time)";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@userid", userid);
                com.Parameters.AddWithValue("@date", date);
                com.Parameters.AddWithValue("@in_time", intime);

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
        }


        // 퇴근 버튼 누를 경우  attendace_log 테이블에 퇴근 시간 데이터 넣기
        public void OffWorkInsert(int userid, string date, string outtime)
        {
            try
            {
                string query = "UPDATE AttendanceLog SET check_out_time  = @outtime WHERE user_id = @name AND attendDate = @date";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@name", userid);
                com.Parameters.AddWithValue("@date", date);
                com.Parameters.AddWithValue("@outtime", outtime);


                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("오류발생: " + e.Message);
            }
        }



        public DataSet AttendanceViewTable()
        {
            DataSet ds = new DataSet();

            try
            {
                string query = "SELECT * FROM AttendanceLog";

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, connection))
                {
                    da.Fill(ds, "AttendanceLogTable");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("AttendanceViewTable 오류발생: " + e.Message);
            }

            return ds;
        }

        internal LoginData GetLoginData()
        {
            LoginData loginData = null;

            try
            {
                // 가장 최근에 등록된 행을 가져오는 쿼리
                string query = "SELECT isAutoLoad, email, password FROM auto_login ORDER BY id DESC LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 데이터베이스에서 가져온 값을 LoginData 객체에 매핑
                            loginData = new LoginData
                            {
                                isAutoLoad = Convert.ToBoolean(reader["isAutoLoad"]),
                                email = reader["email"].ToString(),
                                password = reader["password"].ToString(),
                                
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 예외 처리: 데이터베이스 연결 오류 등
                Console.WriteLine($"Error: {ex.Message}");
            }

            return loginData;
        }

        internal void SetAutoLogin(LoginData loginData)
        {
            try
            {
                // 사용자의 로그인 정보를 데이터베이스에 삽입하는 쿼리
                string insertQuery = "INSERT INTO auto_login (isAutoLoad, email, password) VALUES (@isAutoLoad, @email, @password)";
                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                {
                    // 쿼리에 필요한 매개변수 설정
                    insertCommand.Parameters.AddWithValue("@isAutoLoad", loginData.isAutoLoad);
                    insertCommand.Parameters.AddWithValue("@email", loginData.email);
                    insertCommand.Parameters.AddWithValue("@password", loginData.password);

                    // 쿼리 실행
                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // 예외 처리: 데이터베이스 연결 오류 등
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        internal string GetEmailByUserId(int userId)
        {
            try
            {
                string query = "SELECT email FROM user WHERE user_id = @userId";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString();
                    }
                }

                return null; // 값을 찾지 못한 경우 null 반환
            }
            catch (Exception ex)
            {
                // 예외가 발생했을 때 처리
                Console.WriteLine($"An error occurred in GetUserByEmail: {ex.Message}");
                return null; // 예외 발생 시 null 반환 또는 다른 적절한 처리
            }
        }

        internal List<Message> GetMessagesByUserId(int userId)
        {
            List<Message> messages = new List<Message>();

            string query = "SELECT * FROM message WHERE receiver_id = @userId";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message message = new Message
                            {
                                senderId = reader.GetInt32("sender_id"),
                                receiverId = reader.GetInt32("receiver_id"),
                                content = reader.GetString("content"),
                                sentAt = reader.GetDateTime("sent_at"),
                                isChecked = reader.GetBoolean("isChecked"),
                            };
                            if (message.receiverId == LoginedUserInfo.loginedUserInfo.userId)
                            {
                                message.isChecked = true;
                            }
                            messages.Add(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetMessagesByUserId: {ex.Message}");
            }

            return messages;
        }

        internal async Task<bool> CheckNewMessageForAlarm(int userId)
        {
            Console.WriteLine("CheckNewMessageForAlarm 실행");

            try
            {
                // 알람 테이블에서 행이 있는지 확인
                string checkQuery = "SELECT COUNT(*) FROM alert WHERE user_id = @userId";
                using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@userId", userId);

                    long rowCount = (long)await checkCommand.ExecuteScalarAsync();

                    if (rowCount > 0)
                    {

                        // 알람 테이블에 행이 존재하면 삭제
                        string deleteQuery = "DELETE FROM alert WHERE user_id = @userId";
                        using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@userId", userId);
                            await deleteCommand.ExecuteNonQueryAsync();
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // 예외 처리: 데이터베이스 연결 오류 등
                Console.WriteLine($"Error checking for new messages: {ex.Message}");
                return false;
            }
        }
        // 급여내역서 산출
        public DataSet ViewTableSalary(string month)
        {
            DataSet ds = new DataSet();

            try
            {
                string query = "SELECT user_id AS 아이디, gross_pay AS 총급여, base_pay AS 기본급, n_pension AS 국민연금공제, n_hinsurance AS 국민건강보험공제, n_long_hinsurance AS 장기요양공제, e_insurance AS 고용보험료공제, net_pay AS 순급여 FROM sert_salary WHERE monthofdate = @month";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@month", month);

                using (MySqlDataAdapter da = new MySqlDataAdapter(com))
                {
                    da.Fill(ds);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ViewTableSalary 오류발생: " + e.Message);
            }
            return ds;
        }

        // 업무 시간 산출
        public double GetWorktime(int userid, string date)
        {
            try
            {
                string query = "SELECT check_in_time, check_out_time FROM AttendanceLog WHERE user_id = @name AND attendDate = @date";
                MySqlCommand com = new MySqlCommand(query, connection);
                double totalWorktime = 0;

                com.Parameters.AddWithValue("@name", userid);
                com.Parameters.AddWithValue("@date", date);
                MySqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    string intime = reader.GetString("check_in_time");
                    DateTime checkintime = Convert.ToDateTime(intime);
                    string outtime = reader.GetString("check_out_time");
                    DateTime checkouttime = Convert.ToDateTime(outtime);

                    // Calculate the time difference for each record and accumulate
                    totalWorktime = (checkouttime - checkintime).TotalHours;
                }

                reader.Close(); // Close the reader before returning

                return totalWorktime;
            }
            catch (Exception e)
            {
                MessageBox.Show("GetWorkTime 오류발생: " + e.Message);
                return 0; // Return 0 or another appropriate value in case of an error
            }
        }

        // 급여내역서 user 등록
        public void InsertSalary(int user_id, int month)
        {
            try
            {
                string query = "INSERT INTO sert_salary (email, monthofdate) VALUES (@user_id, @month)";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@user_id", user_id);
                com.Parameters.AddWithValue("@month", month);

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("InsertSalary 오류발생: " + e.Message);
            }
        }

        // 총 급여, 기본급 return
        public (int gross_pay, int base_pay) Getsalary(int userid, int month)
        {
            try
            {
                int gross_pay = 0, base_pay = 0;  // Initialize variables

                string query = "SELECT gross_pay, base_pay FROM sert_salary WHERE user_id = @name AND monthofdate = @month";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@name", userid);
                com.Parameters.AddWithValue("@monthofdate", month);
                MySqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    // Check if "gross_pay" is not DBNull before converting
                    if (!reader.IsDBNull(reader.GetOrdinal("gross_pay")))
                        gross_pay = Convert.ToInt32(reader.GetString("gross_pay"));

                    // Check if "base_pay" is not DBNull before converting
                    if (!reader.IsDBNull(reader.GetOrdinal("base_pay")))
                        base_pay = Convert.ToInt32(reader.GetString("base_pay"));
                }

                reader.Close(); // Close the reader before returning

                return (gross_pay, base_pay);
            }
            catch (Exception e)
            {
                MessageBox.Show("Getsalary 오류발생: " + e.Message);
                return (0, 0); // Return a tuple with default values or handle the error accordingly
            }
        }

        // 급여 입력
        public void InsertPay(int userid, int gross_pay, int base_pay, int n_pension, int n_hinsurance, int n_long_hinsurance, int e_insurance, int net_pay, int month)
        {
            try
            {
                string query = "UPDATE sert_salary SET gross_pay = @gross_pay AND base_pay = @base_pay AND n_pension = @n_pension AND n_hinsurance = @n_hinsurance AND n_long_hinsurance = @n_long_hinsurance AND e_insurance = @e_insurance AND net_pay = @net_pay WHERE user_id = @name AND monthofdate = @month";
                MySqlCommand com = new MySqlCommand(query, connection);
                com.Parameters.AddWithValue("@userid", userid);
                com.Parameters.AddWithValue("@month", month);
                com.Parameters.AddWithValue("@gross_pay", gross_pay);
                com.Parameters.AddWithValue("@base_pay", base_pay);
                com.Parameters.AddWithValue("@n_pension", n_pension);
                com.Parameters.AddWithValue("@n_hinsurance", n_hinsurance);
                com.Parameters.AddWithValue("@n_long_hinsurance", n_long_hinsurance);
                com.Parameters.AddWithValue("@e_insurance", e_insurance);
                com.Parameters.AddWithValue("@net_pay", net_pay);

                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("InsertPay 오류발생: " + e.Message);
            }
        }


    }
}
