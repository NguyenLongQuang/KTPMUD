using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace System
{
    public class ActionResult
    {
        public IView View { get; set; }
    }

    public class RequestContext
    {
        public string Controller { get; set; }
        public string Action { get; set; } = "Index";

        public List<object> Params { get; set; } = new List<object>();
    }

    public class MVC
    {
        static string assembly;
        static Action<ActionResult> updateView;
        static public void Register(object obj, Action<ActionResult> execCallback)
        {
            assembly = obj.GetType().Assembly.GetName().Name;
            updateView = execCallback;
        }

        static public T CreateObject<T>(string typeName)
        {
            var type = Type.GetType($"{assembly}.{typeName}");
            return (T)Activator.CreateInstance(type);
        }

        static public ControllerBase GetController(string name) => CreateObject<ControllerBase>($"Controllers.{name}Controller");
        static public IView GetView(string controller, string action) => CreateObject<IView>($"Views.{controller}.{action}");

        static public void Execute(RequestContext context)
        {
            var ctr = GetController(context.Controller);
            var act = ctr.GetType().GetMethod(context.Action);

            ctr.Request = context;
            var result = (ActionResult)act.Invoke(ctr, new object[] { });
            if (result != null)
            {
                updateView(result);
            }
        }
        static public void Execute(string url, params object[] values) 
        {
            var s = url.Split('/');
            var context = new RequestContext {
                Controller = s[0],
            };

            if (s.Length > 1) context.Action = s[1];
            for (int i = 2; i < s.Length; i++)
            {
                context.Params.Add(s[i]);
            }
            context.Params.AddRange(values);

            Execute(context);
        }
    }
}

namespace System
{
    public class ControllerBase
    {
        public RequestContext Request { get; set; }

        public ActionResult View()
        {
            var view = MVC.GetView(Request.Controller, Request.Action);
            return new ActionResult { View = view };
        }
    }
}

namespace System
{
    public interface IView
    {
        object GetContent();
    }
}
