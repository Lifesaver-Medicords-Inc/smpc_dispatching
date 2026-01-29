using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Interfaces
{
    public interface IRouteService
    {

        Dictionary<string, ViewControlModel> GetAllRoutes();

        Control GetForm(string code);

        string GetTitle(string code);

        IEnumerable<string> GetParents();

        IEnumerable<ViewControlModel> GetChildren(string parent);

        void SelectRoute(string code);
        string GetTitle();

        Control GetForm();

        string GetSelectedRoute();
    }
}
