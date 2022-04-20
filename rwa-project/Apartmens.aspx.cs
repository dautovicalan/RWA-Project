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
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            IRepo repo = RepoFactory.GetRepo();
            Apartments = repo.GetApartments().ToList();

        }
    }
}