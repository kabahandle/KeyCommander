using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class EMenu : ContextMenuStrip
    {
        public EMenu(EventHandler onMenuCliick)
            : base()
        {
            this.BuildMenu(onMenuCliick);
        }

        private void BuildMenu(EventHandler onMenuClick)
        {
            ListMacro lh = ListMacro.GetInstance();
            lh.SortByCategory();
            List<MyItem4MacroListView> macros = lh.Macros;
            string oldCategory = null;
            Dictionary<string, List<MyItem4MacroListView>> dic = new Dictionary<string, List<MyItem4MacroListView>>();
            List<MyItem4MacroListView> tmpList = null;
            foreach (MyItem4MacroListView item in macros)
            {
                if (oldCategory == null )
                {
                    oldCategory = item.Category;
                    tmpList = new List<MyItem4MacroListView>();
                    tmpList.Add(item);
                }
                else if(!item.Category.Equals(oldCategory))
                {
                    if (oldCategory != null && !dic.Keys.Contains(oldCategory))
                    {
                        List<MyItem4MacroListView> list = new List<MyItem4MacroListView>(tmpList);
                        dic.Add(oldCategory, list);
                    }
                    oldCategory = item.Category;
                    tmpList = new List<MyItem4MacroListView>();
                    tmpList.Add(item);
                }
                else
                {
                    tmpList.Add(item);
                }
            }
            if (oldCategory != null && !dic.Keys.Contains(oldCategory))
            {
                List<MyItem4MacroListView> list = new List<MyItem4MacroListView>(tmpList);
                dic.Add(oldCategory, list);
            }

            foreach (string key in dic.Keys)
            {
                ToolStripMenuItem mSubMenu = null;
                List<MyItem4MacroListView> list = dic[key];
                if (!string.IsNullOrEmpty(key))
                {
                    mSubMenu = new ToolStripMenuItem();
                    mSubMenu.Text = key;


                    foreach (MyItem4MacroListView item in list)
                    {
                        if (!string.IsNullOrEmpty(item.Flag) && item.Flag.Contains("M"))
                        {
                            MacroToolStripMenuItem m = new MacroToolStripMenuItem();
                            m.Text = item.Title;
                            m.Item = item;
                            m.Click += onMenuClick;
                            mSubMenu.DropDownItems.Add(m);
                        }
                    }

                    if (mSubMenu != null && mSubMenu.DropDownItems.Count > 0 )
                    {
                        this.Items.Add(mSubMenu);
                    }
                }
                else
                {
                    if( "".Equals(key) )
                    {
                        foreach (MyItem4MacroListView item in list)
                        {
                            if (!string.IsNullOrEmpty(item.Flag) && item.Flag.Contains("M"))
                            {
                                MacroToolStripMenuItem m = new MacroToolStripMenuItem();
                                m.Text = item.Title;
                                m.Item = item;
                                m.Click += onMenuClick;
                                this.Items.Add(m);
                            }
                        }
                    }
                }
            }
            
        }


    }
}
