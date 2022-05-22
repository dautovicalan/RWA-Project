using DataAccessLayer.Dal;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_project
{
    public partial class AddApartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack && Session["user"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            LoadDataToControls();
        }

        private void LoadDataToControls()
        {
            ((IRepo)Application["database"]).GetApartmentOwners()
                .ToList()
                .ForEach(owner => OwnersDropDown.Items
                        .Add(new ListItem { Text = owner.Name, Value = owner.Id.ToString() }));

            ((IRepo)Application["database"]).GetApartmentStatuses()
                .ToList()
                .ForEach(c => StatusDropDown.Items
                       .Add(new ListItem { Text = c.NameEng, Value = c.Id.ToString() }));
            ((IRepo)Application["database"]).GetCitys()
                .ToList()
                .ForEach(city => CityDropDown.Items
                        .Add(new ListItem { Text = city.Name, Value = city.Id.ToString() }));
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            RepoFactory.GetRepo().CreateApartment(new Apartment
            {
                Guid = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                OwnerId = int.Parse(OwnersDropDown.SelectedValue),
                TypeId = 999,
                StatusId = int.Parse(StatusDropDown.SelectedValue),
                CityId = int.Parse(CityDropDown.SelectedValue),
                Address = AddressTextBox.Text,
                Name = NameTextBox.Text,
                NameEng = NameEngTextBox.Text,
                Price = double.Parse(PriceTextBox.Text),
                MaxAdults = int.Parse(maxAdultsSpinner.Text),
                MaxChildren = int.Parse(maxChildrenSpinner.Text),
                TotalRooms = int.Parse(totalRoomsSpinner.Text),
                BeachDistance = int.Parse(beachDistanceSpinner.Text),
            });
            SaveImages();
            Response.Redirect("ShowAllApartments.aspx");
            
        }
        private void SaveImages()
        {
            HttpFileCollection collection = Request.Files;
            for (int i = 0; i < collection.Count; i++)
            {
                HttpPostedFile postedFile = collection[i];
                string fileName = Path.GetFileNameWithoutExtension(postedFile.FileName);
                string fileExtension = Path.GetExtension(postedFile.FileName);
                int fileSize = postedFile.ContentLength;
                //checker za image extensions
                if (postedFile.ContentLength > 0)
                {
                    var test = Environment.CurrentDirectory;
                    Stream stream = postedFile.InputStream;
                    BinaryReader br = new BinaryReader(stream);
                    byte[] bytes = br.ReadBytes((int)stream.Length);
                    ((IRepo)Application["database"]).InsertApartmentPicture(new ApartmentPicture
                    {
                        IsRepresentative = true,
                        ApartmentId = 1,
                        Size = fileSize,
                        ImageData = bytes,
                        Name = fileName + fileExtension,
                    });
                }
            }
        }

    }
}