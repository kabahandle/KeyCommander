using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace KCommander.UserClasses
{
    #region //comparer

    public class SampleComparer<T> : IComparer<T>
    {
        private ListSortDirection _direction;   //ソートの向き（昇順／降順）
        private PropertyDescriptor _property;   //ソート項目

        public SampleComparer(PropertyDescriptor prop, ListSortDirection direction)
        {
            this._property = prop;
            this._direction = direction;
        }

        //同値の場合ゼロを返します。
        int IComparer<T>.Compare(T objX, T objY)
        {
            //比較対象のオブジェクトからクリックしたプロパティを取得します。
            object valX = this.GetPropValue(objX, this._property.Name);
            object valY = this.GetPropValue(objY, this._property.Name);

            //directionの値（昇順／降順）に応じて取得した値を比較します。
            if (this._direction == ListSortDirection.Ascending)
                return this.CompareAsc(valX, valY);
            else
                return this.CompareDesc(valX, valY);
        }
        //昇順で比較を行います。
        private int CompareAsc(object valX, object valY)
        {
            //int ret1 = valY.ToString().ToLower().CompareTo("<dir>");

            //if (ret1 == 0)
            //{
                return (valX.ToString().CompareTo(valY.ToString()));
            //}
            //return ret1;
        }

        //降順で比較を行います。
        private int CompareDesc(object valX, object valY)
        {
            return (this.CompareAsc(valX, valY) * -1);
        }

        //プロパティ値を取得します。
        private object GetPropValue(T val, string prop)
        {
            PropertyInfo propInfo = val.GetType().GetProperty(prop);
            return propInfo.GetValue(val, null);
        }

    }
    #endregion

    #region //BindingList
    public class SortBindingList<T> : BindingList<T>
    {

        private bool _isSorted; //ソート済みか否かを識別します。
        //ソート項目を保持します。
        private PropertyDescriptor _sortProperty;
        //ソート方向（昇順／降順）を保持します。
        private ListSortDirection _sortDirection;

        //リストをバインドします。
        public SortBindingList(T[] items)
        {

            ((List<T>)base.Items).AddRange(items);
        }

        //ソートが可能であることを公開します。
        //このプロパティがtrueで公開されないとソートが実行できません。
        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        //ソートを実行します。
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            //ソートするためバインドされているリストを取得します。
            List<T> items = base.Items as List<T>;

            //リストがあった場合、
            //Comparerを生成してソート項目と項目名を渡します。
            if (items != null)
            {
                SampleComparer<T> sc = new SampleComparer<T>(prop, direction);
                items.Sort(sc);
                //ソート済みに設定します。
                this._isSorted = true;
            }
            else
            {
                this._isSorted = false;
            }

            //ソート結果、方向を保持しておきます。
            this._sortProperty = prop;
            this._sortDirection = direction;

            //リストが変更（ソート）されたことをイベント通知します。
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemMoved, prop));

        }
    }
    #endregion
}
