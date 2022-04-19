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
    public partial class _Default : Page
    {

        public List<Apartment> Apartments { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            IRepo repo = RepoFactory.GetRepo();
            IList<Apartment> apartmens = repo.GetApartments();
            Apartment apartment = repo.GetApartmentById(1);
            Apartments = repo.GetApartments().ToList();
            Tag helloTag = repo.GetTagById(1);

            string init = "";
            apartmens.ToList().ForEach(apartm => init += $"{apartm.Name} ");
           

            lblTest.Text = helloTag.NameEng;            
        }
    }
}