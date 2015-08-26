using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vilin.Web
{
    public partial class SessionCluster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["key"] != null)
            {
                string key = DateTime.Now.Ticks.ToString();
                Session[key] = "Hello " + Request.QueryString["key"].ToString();
                Literal1.Text = Session[key].ToString();
            }
        }
    }
}