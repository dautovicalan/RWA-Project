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
    public partial class EditApartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // fix routing stuff
            var testing = Page.RouteData.Values;
            //Apartment apart = RepoFactory.GetRepo().GetApartmentById(int.Parse(Page.RouteData.Values["id"].ToString()));
            //Label1.Text = RepoFactory.GetRepo().GetApartmentById(int.Parse(Page.RouteData.Values["id"].ToString())).Name;
        }
    }
}