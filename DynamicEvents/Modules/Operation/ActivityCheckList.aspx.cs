﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dynamic_Events.Modules.Operation
{
    public partial class ActivityCheckList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Url = "http://localhost/DynamicEventsAPI/api/Activity/CheckStatus?barcodeNo=" + Request.QueryString["barcodeNo"];
                storeDetail.SetProxyUrl(Url);
            }
            
        }
    }
}