namespace Zing.Framework.UI
{
    using System.Web.Routing;
    using Zing.Framework.Utility;
    
    public class RequestSettings : INavigatable
    {
        private string routeName;
        private string controllerName;
        private string actionName;

        public RequestSettings()
        {
            RouteValues = new RouteValueDictionary();
        }

        public string ActionName
        {
            get
            {
                return actionName;
            }
            set
            {
                Guard.IsNotNullOrEmpty(value, "value");

                actionName = value;

                routeName = null;
            }
        }

        public string ControllerName
        {
            get
            {
                return controllerName;
            }
            set
            {
                Guard.IsNotNullOrEmpty(value, "value");

                controllerName = value;

                routeName = null;
            }
        }

        public RouteValueDictionary RouteValues
        {
            get;
            set;
        }

        public string RouteName
        {
            get
            {
                return routeName;
            }
            set
            {
                Guard.IsNotNullOrEmpty(value, "value");

                routeName = value;
                controllerName = actionName = null;
            }
        }

        public string Url
        {
            get;
            set;
        }
    }
}
