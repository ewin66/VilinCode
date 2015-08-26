using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vilin.Common.ThreadQueue;

namespace Vilin.Web.ThreadQueue
{
    public partial class SubmitOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OrderModel ob = new OrderModel();
            ob.SourceManualResetEvent = new ManualResetEvent(false);
            ob.key = Session.SessionID;
            ob.state = 0;

            ThreadQueueCore<OrderModel>.Add(ob);
            ob = ThreadQueueCore<OrderModel>.Get(ob.key);

            litMsg.Text = string.Format("key:{0}, state:{1}", ob.key, ob.state);
        }
    }
}