using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CrmClientsManager.UI
{
    public partial class CloseTicketForm : Form
    {
        private DateTimePicker dtCloseDate;
        private TextBox txtComment;
        private Button btnConfirm;


        public DateTime CloseDate =>
            dtCloseDate.Value;


        public string Comment =>
            txtComment.Text;


        public CloseTicketForm()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            dtCloseDate = new DateTimePicker();
            txtComment = new TextBox();
            btnConfirm = new Button();


            dtCloseDate.Location =
                new Point(20, 20);

            dtCloseDate.Width = 250;


            txtComment.Location =
                new Point(20, 70);

            txtComment.Width = 250;
            txtComment.Height = 100;
            txtComment.Multiline = true;

            txtComment.PlaceholderText =
                "Resolution comment";


            btnConfirm.Location =
                new Point(20, 200);

            btnConfirm.Text =
                "Close ticket";

            btnConfirm.Click +=
                btnConfirm_Click;


            Controls.Add(dtCloseDate);
            Controls.Add(txtComment);
            Controls.Add(btnConfirm);


            Text = "Close Ticket";
            Size = new Size(320, 300);
        }


        private void btnConfirm_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Comment))
            {
                MessageBox.Show(
                    "Resolution comment is required.");

                return;
            }


            DialogResult =
                DialogResult.OK;
        }
    }
}
