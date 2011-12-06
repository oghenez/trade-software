using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using application;
using commonClass;

namespace baseClass
{
    public class language
    {
        public static void SetLanguage(common.controls.baseComboBox combo, Type type)
        {
            int saveIdx = combo.SelectedIndex;
            SetLanguage(combo.Items, type);
            if (saveIdx >= 0) combo.SelectedIndex = saveIdx;
        }
        public static void SetLanguage(common.controls.baseCheckedListBox list, Type type)
        {
            SetLanguage(list.Items, type);
        }

        public static void SetLanguage(ComboBox.ObjectCollection items, Type type)
        {
            StringCollection saveKeys = new StringCollection();
            for (int idx = 0; idx < items.Count; idx++)
            {
                common.myComboBoxItem item = (common.myComboBoxItem)items[idx];
                saveKeys.Add(item.Value);
            }
            if (type == typeof(AppTypes.TimeScale))
            {
                items.Clear();
                foreach (AppTypes.TimeScale item in AppTypes.myTimeScales)
                {
                    if (!saveKeys.Contains(item.Code)) continue;
                    items.Add(new common.myComboBoxItem(item.Description, item.Code));
                }
                return;
            }

            if (type == typeof(AppTypes.TradeActions))
            {
                items.Clear();
                foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }

            if (type == typeof(AppTypes.TimeRanges))
            {
                items.Clear();
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.StrategyTypes))
            {
                items.Clear();
                foreach (AppTypes.StrategyTypes item in Enum.GetValues(typeof(AppTypes.StrategyTypes)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.Sex))
            {
                items.Clear();
                foreach (AppTypes.Sex item in Enum.GetValues(typeof(AppTypes.Sex)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.CommonStatus))
            {
                items.Clear();
                foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.ChartTypes))
            {
                items.Clear();
                foreach (AppTypes.ChartTypes item in Enum.GetValues(typeof(AppTypes.ChartTypes)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.BizSectorTypes))
            {
                items.Clear();
                foreach (AppTypes.BizSectorTypes item in Enum.GetValues(typeof(AppTypes.BizSectorTypes)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
        }

        public static void SetLanguage(CheckedListBox.ObjectCollection items, Type type)
        {
            StringCollection saveKeys = new StringCollection();
            for (int idx = 0; idx < items.Count; idx++)
            {
                common.myComboBoxItem item = (common.myComboBoxItem)items[idx];
                saveKeys.Add(item.Value);
            }
            if (type == typeof(AppTypes.TimeScale))
            {
                items.Clear();
                foreach (AppTypes.TimeScale item in AppTypes.myTimeScales)
                {
                    if (!saveKeys.Contains(item.Code)) continue;
                    items.Add(new common.myComboBoxItem(item.Description, item.Code));
                }
                return;
            }

            if (type == typeof(AppTypes.TradeActions))
            {
                items.Clear();
                foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }

            if (type == typeof(AppTypes.TimeRanges))
            {
                items.Clear();
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.StrategyTypes))
            {
                items.Clear();
                foreach (AppTypes.StrategyTypes item in Enum.GetValues(typeof(AppTypes.StrategyTypes)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.Sex))
            {
                items.Clear();
                foreach (AppTypes.Sex item in Enum.GetValues(typeof(AppTypes.Sex)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.CommonStatus))
            {
                items.Clear();
                foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.ChartTypes))
            {
                items.Clear();
                foreach (AppTypes.ChartTypes item in Enum.GetValues(typeof(AppTypes.ChartTypes)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.BizSectorTypes))
            {
                items.Clear();
                foreach (AppTypes.BizSectorTypes item in Enum.GetValues(typeof(AppTypes.BizSectorTypes)))
                {
                    if (!saveKeys.Contains(item.ToString())) continue;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
        }
    }
}
