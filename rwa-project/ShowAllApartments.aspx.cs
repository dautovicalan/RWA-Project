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
        public IList<ApartmentPicture> ApartmentPictures { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
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

        protected void AddNewApartment_Click(object sender, EventArgs e) => Response.Redirect("AddApartment.aspx");

        protected void EditButton_Click(object sender, EventArgs e)
        {
            ((IRepo)Application["database"]).UpdateApartmentById(new Apartment
            {
                Id = int.Parse(Session["selectedApartmentId"].ToString()),
                TotalRooms = int.Parse(txbRoomNumber.Text),
                MaxAdults = int.Parse(txbAdultsNumber.Text),
                MaxChildren = int.Parse(txbChildrenNumber.Text),
                BeachDistance = int.Parse(txbBeachDistance.Text),
                StatusId = int.Parse(ddlApartmentStatuses.SelectedValue)
            });
            FillData();
            EditApartmentPanel.Visible = false;
        }

        protected void DeleteButton_Click(object sender, EventArgs e) => pnlModal.Visible = true;

        protected void btnDeleteCancel_Click(object sender, EventArgs e) => pnlModal.Visible = false;

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {            
            ((IRepo)Application["database"]).SoftDeleteApartmentById(int.Parse(ApartmentId.Text));
            pnlModal.Visible = false;
            EditApartmentPanel.Visible = false;
            FillData();
        }

        protected void btnAddApartment_Click(object sender, EventArgs e) => Response.Redirect("AddApartment.aspx");

        protected void btnSort_Click(object sender, EventArgs e) => FillData(int.Parse(ddlSortType.SelectedValue));
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
                    Session["selectedApartmentId"] = selectedApartment.Id;
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
            FillDropDownListsWithTags(selectedApartment.Id);
            DisplayPictures(selectedApartment.Id);
        }

        private void DisplayPictures(int apartId)
        {
            imgRepeater.DataSource = ((IRepo)Application["database"]).GetAllApartmentPictures(apartId);
            imgRepeater.DataBind();
        }

        private void FillDropDownListsWithTags(int selectedApartmentId)
        {
            ddlApartmentTags.Items.Clear();
            ddlAllOtherTags.Items.Clear();
            ((IRepo)Application["database"]).GetApartmentTags(selectedApartmentId)
               .ToList().ForEach(element => ddlApartmentTags.Items.Add(new ListItem { Text = element.Name, Value = element.Id.ToString() }));
            FilterTagsForApartment(selectedApartmentId).ForEach(x => ddlAllOtherTags.Items.Add(new ListItem { Text = x.Name, Value = x.Id.ToString() }));
        }

        private List<Tag> FilterTagsForApartment(int id)
        {
            List<Tag> allTags = ((IRepo)Application["database"]).GetTags().ToList();
            List<Tag> existinTags = ((IRepo)Application["database"]).GetApartmentTags(id).ToList();            

            List<Tag> filteredTags = new List<Tag>();

            foreach (Tag item in allTags)
            {
                if (!existinTags.Exists(x => x.Id == item.Id))
                {     
                    filteredTags.Add(item);
                }
            }
            return filteredTags;
        }

        protected void addOtherTagToApartment_Click(object sender, EventArgs e)
        {            
            ((IRepo)Application["database"]).InsertTagToApartment(int.Parse(ApartmentId.Text), int.Parse(ddlAllOtherTags.SelectedValue));
            FillDropDownListsWithTags(int.Parse(ApartmentId.Text));
        }

        protected void imgRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                ((IRepo)Application["database"]).SoftDeleteApartmentPicture(int.Parse(e.CommandArgument.ToString()));
                DisplayPictures(int.Parse(Session["selectedApartmentId"].ToString()));
            }
            if (e.CommandName == "SetMain")
            {
                ((IRepo)Application["database"]).UpdateApartmentMainPicture(int.Parse(e.CommandArgument.ToString()), int.Parse(Session["selectedApartmentId"].ToString()));
            }
        }

        protected void removeTagFromApartmentButton_Click(object sender, EventArgs e)
        {
            ((IRepo)Application["database"]).DeleteTagFromApartment(int.Parse(ApartmentId.Text), int.Parse(ddlApartmentTags.SelectedValue));
            FillDropDownListsWithTags(int.Parse(ApartmentId.Text));
        }
    }
}