using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student
{
    public partial class wfrStudent : System.Web.UI.Page
    {
        Int32 gioiTinh;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        void loadData()
        {
            try
            {
                clsDatabase.OpenConnection();
                DataTable t = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from SinhVien", clsDatabase.con);

                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset, "SinhVien");
                grvStudent.DataSource = dataset.Tables["SinhVien"];
                //da.Fill(t);
                //GrvStudent.DataSource = t;
                grvStudent.DataBind();
                clsDatabase.CloseConnection();
            }
            catch (Exception)
            {

            }
        }

        protected void grvStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvStudent.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void grvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string datakey = grvStudent.DataKeys[e.RowIndex].Value.ToString();
            try
            {
                clsDatabase.OpenConnection();
                SqlCommand com = new SqlCommand("Delete from sinhvien where masv='" + datakey + "'", clsDatabase.con);
                com.ExecuteNonQuery();
                Response.Write("XÓA THÔNG TIN THÀNH CÔNG:  " + datakey);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            loadData();
        }

        protected void grvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvStudent.EditIndex = e.NewEditIndex;
            loadData();
        }

        protected void grvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtHoTen = grvStudent.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox;
            TextBox txtLop = grvStudent.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox;
            CheckBox ChkGioiTinh = grvStudent.Rows[e.RowIndex].Cells[3].Controls[0] as CheckBox;
            string datakey = grvStudent.DataKeys[e.RowIndex].Value.ToString();
            try
            {
                clsDatabase.OpenConnection();
                if (ChkGioiTinh.Checked == true)
                {
                    gioiTinh = 1;
                }
                else
                {
                    gioiTinh = 0;
                }
                SqlCommand com = new SqlCommand("update Sinhvien set TenSV=@tenSV, Phai=@gioiTinh, Lop=@lop where MaSV='" + datakey + "'", clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@tenSV", SqlDbType.NVarChar);
                p1.Value = txtHoTen.Text;
                SqlParameter p2 = new SqlParameter("@gioiTinh", SqlDbType.Bit);
                p2.Value = Convert.ToBoolean(gioiTinh);
                SqlParameter p3 = new SqlParameter("@lop", SqlDbType.NVarChar);
                p3.Value = txtLop.Text;
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.ExecuteNonQuery();
                Response.Write("CẬP NHẬT THÔNG TIN THÀNH CÔNG: " + datakey);
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + txtHoTen.Text + gioiTinh.ToString() + txtLop.Text);
            }
        }

        protected void grvStudent_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string datakey = grvStudent.DataKeys[e.NewSelectedIndex].Value.ToString();
            Response.Write("MÃ SỐ SINH VIÊN: " + datakey);
        }

        protected void grvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvStudent.EditIndex = -1;
            loadData();
        }
    }
}
class clsDatabase
{
    public static SqlConnection con;

    public static bool OpenConnection()
    {
        try
        {
            //login with window authentication option, so there are no user name and password
            con = new SqlConnection("Data Source=DESKTOP-E30J54Q\\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True");
            con.Open();
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public static bool CloseConnection()
    {
        try
        {
            con.Close();
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

}

