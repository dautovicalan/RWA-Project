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
    public partial class AddApartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataToControls();
        }

        private void LoadDataToControls()
        {
            IRepo repo = RepoFactory.GetRepo();

            repo.GetApartmentOwners()
                .ToList()
                .ForEach(owner => OwnersDropDown.Items
                        .Add(new ListItem { Text = owner.Name, Value = owner.Id.ToString() }));

            repo.GetApartmentStatuses()
                .ToList()
                .ForEach(c => StatusDropDown.Items
                       .Add(new ListItem { Text = c.NameEng, Value = c.Id.ToString() }));
            repo.GetCitys()
                .ToList()
                .ForEach(city => CityDropDown.Items
                        .Add(new ListItem { Text = city.Name, Value = city.Id.ToString() }));

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

        }
    }
}