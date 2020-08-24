using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class RootControl : System.Web.UI.Page
    {
        RootMenuBLL rootMenuBLL = new RootMenuBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            ReLeftMenuSource();
        }

        void ReLeftMenuSource()
        {
            List<RootMenuModel> Menus = rootMenuBLL.ToModel(rootMenuBLL.SelectALL());
            foreach (RootMenuModel menu in Menus)
            {
                if (menu.ParentID == 0)
                {
                    TREEVIEW_LeftMenu.Nodes.Add(new TreeNode() { Value = menu.ID.ToString(), Text = menu.Title,NavigateUrl=menu.Link, Target= "DisplayForm" });
                }
                else
                {
                    for (int f = 0; f < TREEVIEW_LeftMenu.Nodes.Count; f++)
                    {
                        TreeNode node = TREEVIEW_LeftMenu.Nodes[f];
                        if (node.Value == menu.ParentID.ToString())
                        {
                            TREEVIEW_LeftMenu.Nodes[f].ChildNodes.Add(new TreeNode() { Value = menu.ID.ToString(), Text = menu.Title, NavigateUrl = menu.Link, Target = "DisplayForm" });
                            break;
                        }
                    }
                }
            }
        }
    }
}