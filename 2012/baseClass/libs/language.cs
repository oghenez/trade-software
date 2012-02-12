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

        //Swicth language. Note that the order of items must be preserved
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
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindTimeScaleByCode(saveKeys[idx]);
                    if (obj == null) continue;
                    AppTypes.TimeScale item = (AppTypes.TimeScale)obj;
                    items.Add(new common.myComboBoxItem(item.Description, item.Code));
                }
                return;
            }

            if (type == typeof(AppTypes.LanguageCodes))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.LanguageCodes));
                    if (obj == null) continue;
                    AppTypes.LanguageCodes item = (AppTypes.LanguageCodes)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }

            if (type == typeof(AppTypes.TradeActions))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count;idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.TradeActions));
                    if (obj==null) continue;
                    AppTypes.TradeActions item = (AppTypes.TradeActions)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }


            if (type == typeof(AppTypes.TimeRanges))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.TimeRanges));
                    if (obj == null) continue;
                    AppTypes.TimeRanges item = (AppTypes.TimeRanges)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.StrategyTypes))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.StrategyTypes));
                    if (obj == null) continue;
                    AppTypes.StrategyTypes item = (AppTypes.StrategyTypes)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.Sex))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.Sex));
                    if (obj == null) continue;
                    AppTypes.Sex item = (AppTypes.Sex)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.CommonStatus))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.CommonStatus));
                    if (obj == null) continue;
                    AppTypes.CommonStatus item = (AppTypes.CommonStatus)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.ChartTypes))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.ChartTypes));
                    if (obj == null) continue;
                    AppTypes.ChartTypes item = (AppTypes.ChartTypes)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.BizSectorTypes))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.BizSectorTypes));
                    if (obj == null) continue;
                    AppTypes.BizSectorTypes item = (AppTypes.BizSectorTypes)obj;
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
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindTimeScaleByCode(saveKeys[idx]);
                    if (obj == null) continue;
                    AppTypes.TimeScale item = (AppTypes.TimeScale)obj;
                    items.Add(new common.myComboBoxItem(item.Description, item.Code));
                }
                return;
            }

            if (type == typeof(AppTypes.TradeActions))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.TradeActions));
                    if (obj == null) continue;
                    AppTypes.TradeActions item = (AppTypes.TradeActions)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }

            if (type == typeof(AppTypes.TimeRanges))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.TimeRanges));
                    if (obj == null) continue;
                    AppTypes.TimeRanges item = (AppTypes.TimeRanges)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.StrategyTypes))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.StrategyTypes));
                    if (obj == null) continue;
                    AppTypes.StrategyTypes item = (AppTypes.StrategyTypes)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.Sex))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.Sex));
                    if (obj == null) continue;
                    AppTypes.Sex item = (AppTypes.Sex)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.CommonStatus))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.CommonStatus));
                    if (obj == null) continue;
                    AppTypes.CommonStatus item = (AppTypes.CommonStatus)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.ChartTypes))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.ChartTypes));
                    if (obj == null) continue;
                    AppTypes.ChartTypes item = (AppTypes.ChartTypes)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
            if (type == typeof(AppTypes.BizSectorTypes))
            {
                items.Clear();
                for (int idx = 0; idx < saveKeys.Count; idx++)
                {
                    object obj = FindCodeInEnum(saveKeys[idx], typeof(AppTypes.BizSectorTypes));
                    if (obj == null) continue;
                    AppTypes.BizSectorTypes item = (AppTypes.BizSectorTypes)obj;
                    items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
                }
                return;
            }
        }

        private static AppTypes.TradeActions FindTradeAction(string code)
        {
            foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
            {
                if (item.ToString() == code) return item;
            }
            return AppTypes.TradeActions.None;
        }
        private static object FindCodeInEnum(string code,Type enumType)
        {
            foreach (object item in Enum.GetValues(enumType))
            {
                if (item.ToString() == code) return item;
            }
            return null;
        }

        private static object FindTimeScaleByCode(string code)
        {
            foreach (AppTypes.TimeScale item in AppTypes.myTimeScales)
            {
                if (item.Code == code) return item;
            }
            return null;
        }
    }
}
