using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UFCfinal.myclass;
using MySql.Data.MySqlClient;

namespace UFCfinal
{
    public partial class Form1 : Form
    {
        CRUD crud = new CRUD();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            UClear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // CREATE
            Create();
            Read();
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // UPDATE
            Update();
            Read();
            UClear();
      
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // DELETE
            Delete();
            Read();
            UClear();
        }

        // READ
        public void Read()
        {
            dataGridView1.DataSource = null;
            crud.ReadData();
            dataGridView1.DataSource = crud.dt;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "IME";
            dataGridView1.Columns[2].HeaderText = "PREZIME";
            dataGridView1.Columns[3].HeaderText = "ZEMLJA";

        }

        // CREATE
        public void Create()
        {
            crud.ime_sudac = imetxt.Text;
            crud.prezime_sudac = prezimetxt.Text;
            crud.zemlja_id = int.Parse(zemljatxt.Text);
            crud.CreateData();
        }

        // UPDATE
        public void Update()
        {
            crud.ime_sudac = u_imetxt.Text;
            crud.prezime_sudac = u_prezimetxt.Text;
            crud.zemlja_id = int.Parse(u_zemljatxt.Text);
            crud.id_sudac = int.Parse(u_idtxt.Text);
            crud.UpdateData();
        }

        // DELETE
        public void Delete()
        {
            crud.id_sudac = int.Parse(u_idtxt.Text);
            crud.DeleteData();

        }

        // CLEAR
        public void Clear()
        {
            imetxt.Text = "";
            prezimetxt.Text = "";
            zemljatxt.Text = "";
        }

        // UPDATE CLEAR
        public void UClear()
        {
            u_idtxt.Text = "";
            u_imetxt.Text = "";
            u_prezimetxt.Text = "";
            u_zemljatxt.Text = "";
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // GET DATA
            DataGridView senderGrid = (DataGridView)sender;

            try
            {
                if (dataGridView1.Rows[senderGrid.CurrentCell.RowIndex].Cells[senderGrid.CurrentCell.ColumnIndex].Value != null)
                {
                    u_idtxt.Text = (dataGridView1.Rows[senderGrid.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    u_imetxt.Text = (dataGridView1.Rows[senderGrid.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    u_prezimetxt.Text = (dataGridView1.Rows[senderGrid.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    u_zemljatxt.Text = (dataGridView1.Rows[senderGrid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ne klikaj atribute!");
            }
        }

    }
}
