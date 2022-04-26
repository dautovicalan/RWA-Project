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
    public partial class ShowAllReservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void cbIsNotRegisteredUser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsNotRegisteredUser.Checked)
            {
                pnlNotRegisteredUser.Visible = true;
                pnlRegisteredUsers.Visible = false;
                return;
            }
            pnlNotRegisteredUser.Visible = false;
            pnlRegisteredUsers.Visible = true;
        }

        protected void AddReservationButton_Click(object sender, EventArgs e)
        {
            if (!cbIsNotRegisteredUser.Checked)
            {
                ((IRepo)Application["database"]).CreateApartmentReservationRegisteredUser(new ApartmentReservation
                {
                    Guid = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    ApartmentId = int.Parse(ddlApartments.SelectedValue),
                    Details = tbDetails.Text,
                    UserId = int.Parse(ddlRegisteredUsers.SelectedValue),
                });
                GridView1.DataBind();
                return;
            }
            ((IRepo)Application["database"]).CreateApartmentReservationNonRegisteredUser(new ApartmentReservation
            {
                Guid = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                ApartmentId = int.Parse(ddlApartments.SelectedValue),
                Details = tbDetails.Text,
                UserName = tbUserName.Text,
                UserEmail = tbUserEmail.Text,
                UserPhone = tbUserPhone.Text,
                UserAddress = tbUserAddress.Text,
            });
            GridView1.DataBind();
            CleanForm();

        }

        private void CleanForm()
        {
            tbDetails.Text = "";
            tbUserEmail.Text = "";
            tbUserName.Text = "";
            tbUserPhone.Text = "";
            tbUserAddress.Text = "";
        }
    }

}