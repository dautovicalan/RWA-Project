﻿using DataAccessLayer.Dal;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack && Session["user"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            Repeater1.DataSource = ((IRepo)Application["database"]).GetApartments();
            Repeater1.DataBind();
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
            //ApartmentId.Text = GridView1.SelectedRow.Cells[0].Text;
            //txbRoomNumber.Text = GridView1.SelectedRow.Cells[5].Text;
            //txbAdultsNumber.Text = GridView1.SelectedRow.Cells[3].Text;
            //txbChildrenNumber.Text = GridView1.SelectedRow.Cells[4].Text;
            //txbBeachDistance.Text = GridView1.SelectedRow.Cells[8].Text;            
            //ddlApartmentStatuses.SelectedValue = ddlApartmentStatuses.Items.Cast<ListItem>().ToList()
            //    .Find(singleItem => singleItem.Text == GridView1.SelectedRow.Cells[9].Text).Value;
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //((IRepo)Application["database"]).UpdateApartmentById(new Apartment
            //{
            //    Id = int.Parse(GridView1.SelectedRow.Cells[0].Text),
            //    TotalRooms = int.Parse(txbRoomNumber.Text),
            //    MaxAdults = int.Parse(txbAdultsNumber.Text),
            //    MaxChildren = int.Parse(txbChildrenNumber.Text),
            //    BeachDistance = int.Parse(txbBeachDistance.Text),
            //    StatusId = int.Parse(ddlApartmentStatuses.SelectedValue)
            //});
            //GridView1.DataBind();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            RepoFactory.GetRepo().SoftDeleteApartmentById(int.Parse(ApartmentId.Text));
            //GridView1.DataBind();
        }

        protected void btnAddApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddApartment.aspx");
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            //string expression = "";
            //SortDirection direction;

            //expression = "Status";

            //switch (ddlSortType.SelectedValue)
            //{
            //    case "Osoba":
            //        direction = SortDirection.Ascending;
            //        break;
            //    default:
            //        direction = SortDirection.Descending;
            //        break;
            //}

            //GridView1.Sort(expression, direction);

        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int statusId = int.Parse(ddlStatus.SelectedValue.ToString());
            int cityId = int.Parse(ddlCity.SelectedValue.ToString());

            Repeater1.DataSource = ((IRepo)Application["database"]).GetApartmentsFilteredByStatusCity(statusId, cityId);
            Repeater1.DataBind();
        }
    }
}