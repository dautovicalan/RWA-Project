using DataAccessLayer.Dal;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_project
{
    public partial class Apartmens : System.Web.UI.Page
    {
        public List<Apartment> Apartments { get; set; }        

        protected void Page_Load(object sender, EventArgs e)
        {

        }
      
        protected void AddNewApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddApartment.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditApartmentPanel.Visible = true;
            FillEditForm();
        }

        private void FillEditForm()
        {
            ApartmentId.Text = GridView1.SelectedRow.Cells[0].Text;
            txbRoomNumber.Text = GridView1.SelectedRow.Cells[5].Text;
            txbAdultsNumber.Text = GridView1.SelectedRow.Cells[3].Text;
            txbChildrenNumber.Text = GridView1.SelectedRow.Cells[4].Text;
            txbBeachDistance.Text = GridView1.SelectedRow.Cells[8].Text;
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            RepoFactory.GetRepo().SoftDeleteApartmentById(int.Parse(ApartmentId.Text));
            GridView1.DataBind();
        }
    }
}