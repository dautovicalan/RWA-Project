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
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack && Session["user"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            FillData();
        }

        private void FillData(int sortType = 2)
        {
            List<Apartment> apartments = ((IRepo)Application["database"]).GetApartments().ToList();
            SortGivenApartments(sortType, apartments);
            Repeater1.DataSource = apartments;
            Repeater1.DataBind();
        }

        private void SortGivenApartments(int sortType, List<Apartment> apartments)
        {
            if (rbAsc.Checked)
            {
                switch (sortType)
                {
                    case 0:
                        apartments.Sort((x, y) => x.MaxAdults.CompareTo(y.MaxAdults));
                        break;
                    case 1:
                        apartments.Sort((x, y) => x.TotalRooms.CompareTo(y.TotalRooms));
                        break;
                    case 2:
                        apartments.Sort((x, y) => x.Price.CompareTo(y.Price));
                        break;
                    default:
                        apartments.Sort((x, y) => x.Price.CompareTo(y.Price));
                        break;
                }
            }
            else
            {
                switch (sortType)
                {
                    case 0:
                        apartments.Sort((x, y) => -x.MaxAdults.CompareTo(y.MaxAdults));
                        break;
                    case 1:
                        apartments.Sort((x, y) => -x.TotalRooms.CompareTo(y.TotalRooms));
                        break;
                    case 2:
                        apartments.Sort((x, y) => -x.Price.CompareTo(y.Price));
                        break;
                    default:
                        apartments.Sort((x, y) => -x.Price.CompareTo(y.Price));
                        break;
                }
            }
            
        }

        protected void AddNewApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddApartment.aspx");
        }
      
        protected void EditButton_Click(object sender, EventArgs e)
        {
            ((IRepo)Application["database"]).UpdateApartmentById(new Apartment
            {
                Id = int.Parse(ApartmentId.Text),
                TotalRooms = int.Parse(txbRoomNumber.Text),
                MaxAdults = int.Parse(txbAdultsNumber.Text),
                MaxChildren = int.Parse(txbChildrenNumber.Text),
                BeachDistance = int.Parse(txbBeachDistance.Text),
                StatusId = int.Parse(ddlApartmentStatuses.SelectedValue)
            });
            FillData();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            ((IRepo)Application["database"]).SoftDeleteApartmentById(int.Parse(ApartmentId.Text));
            FillData();
        }

        protected void btnAddApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddApartment.aspx");
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            int sortingType = int.Parse(ddlSortType.SelectedValue);
            FillData(sortingType);
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int statusId = int.Parse(ddlStatus.SelectedValue.ToString());
            int cityId = int.Parse(ddlCity.SelectedValue.ToString());

            Repeater1.DataSource = ((IRepo)Application["database"]).GetApartmentsFilteredByStatusCity(statusId, cityId);
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Open")
            {

                Apartment selectedApartment = ((IRepo)Application["database"]).GetApartmentById(int.Parse(e.CommandArgument.ToString()));
                if (selectedApartment != null)
                {
                    FillEditForm(selectedApartment);
                }
            }
        }

        private void FillEditForm(Apartment selectedApartment)
        {
            EditApartmentPanel.Visible = true;
            ApartmentId.Text = selectedApartment.Id.ToString();
            txbRoomNumber.Text = selectedApartment.TotalRooms.ToString();
            txbAdultsNumber.Text = selectedApartment.MaxAdults.ToString();
            txbChildrenNumber.Text = selectedApartment.MaxChildren.ToString();
            txbBeachDistance.Text = selectedApartment.BeachDistance.ToString();
            ddlApartmentStatuses.SelectedValue = ddlApartmentStatuses.Items.Cast<ListItem>().ToList()
                .Find(singleItem => singleItem.Text == selectedApartment.StatusName).Value;
        }
    }
}