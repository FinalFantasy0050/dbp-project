using deepcheesebacon.SourceCode.ApprovalSystem;

namespace deepcheesebacon
{
    public partial class ApprovalSystemMainForm : Form
    {

        ApprovalService approvalService;
        public ApprovalSystemMainForm()
        {
            InitializeComponent();
            approvalService = new ApprovalService();
            LoadDataGridViewApprovalList();
            LoadDataGridViewTaskSummary();
        }

        private void LoadDataGridViewTaskSummary()
        {
            approvalService.LoadDataGridViewTaskSummary(dataGridViewTaskSummary);
        }

        private void buttonCreateNewApproval_Click(object sender, EventArgs e)
        {
            CreateNewApprovalForm newApprovalForm = new CreateNewApprovalForm();

            newApprovalForm.ShowDialog();

            LoadDataGridViewApprovalList();
            LoadDataGridViewTaskSummary();
        }

        private void LoadDataGridViewApprovalList()
        {
            approvalService.LoadDataGridViewApprovalList(dataGridViewApprovalList);
        }

        private void buttonCheckMyApprovalList_Click(object sender, EventArgs e)
        {
            CheckMyApprovalListForm newApprovalListForm = new CheckMyApprovalListForm();
            newApprovalListForm.ShowDialog();
            LoadDataGridViewApprovalList();
            LoadDataGridViewTaskSummary();
        }

        private void dataGridViewApprovalList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
