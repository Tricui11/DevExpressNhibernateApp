   M S B A M L   `   `   `  ����H  DStoreWPFDXApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StoreWPFDXApp.ViewModelsStoreWPFDXApp.ViewModels  5	   	   ;"clr-namespace:StoreWPFDXApp.CommonStoreWPFDXApp.Common  5
   	   (    "StoreWPFDXApp.Views.CategoriesView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aF 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   a ]DevExpress.Xpf.Grid.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Grid.v21.2.Extensions, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v21.2.Core, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid    5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   7
ViewModels&clr-namespace:StoreWPFDXApp.ViewModels  5	   	   /common"clr-namespace:StoreWPFDXApp.Common  5
   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6;   $	��450��5      $	��700��6'     � Title$  Категории��5   	    � WindowStartupLocation$ CenterScreen=�6    � DataContext 5   	   #   StoreWPFDXApp.Common.DISource     Type$$ ViewModels:CategoriesViewModelL�.��5      ]� .+�5   
   )  #DevExpress.Xpf.Grid.TreeListControl  )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6   �� *
Categories+   SelectedItem 6A   �� *SelectedCategory+   View 5      &   DevExpress.Xpf.Grid.TreeListView  5      -   5          Name$ tlView��5   #      KeyFieldName$
 UuId��5   #   	   ParentFieldName$	 
ParentUuId��5   #   
   AllowPerPixelScrolling
 .    AutoExpandAllNodes .    TreeColumnFieldName$
 Name��5   #      NewItemRowPosition$ Bottom=�5   #      	AutoWidth . &   DevExpress.Xpf.Grid.DataViewBase   NavigationStyle$
 Cell=�5   #      AllowDragDrop .    ShowDragDropHint .     	RowIndent$ 16Q�5   #      UseEvenRowBackground .    EnterMoveNextColumn .     FormatConditions 5      )  #DevExpress.Xpf.Grid.FormatCondition  5       -  'DevExpress.Xpf.Grid.FormatConditionBase   	FieldName$ IsNew��6.      PredefinedFormatName$ BoldText��6@      
Expression$ [IsUpdated] = true��6`      
ApplyToRow . 6�       RowCellMenuCustomizations 5"      '  !DevExpress.Xpf.Bars.BarButtonItem  5#      -   5        !	  DevExpress.Xpf.Bars.BarItem 	  Content)
  #DevExpress.Xpf.Core.ObjectConverter$ Удалить
 5#   X    	  Glyph 6,   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Delete_16x16.png  	  Command 5$   H   �� *,*View.DataContext.DeleteSelectedItemCommand+5&         Columns. 5(      (  "DevExpress.Xpf.Grid.TreeListColumn  $  DevExpress.Xpf.Grid.ColumnBase    	FieldName$
  Name��6!   $  DevExpress.Xpf.Grid.BaseColumn!   Header$! Наименование
 62   "   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	" 150 6H     5)      $  Description��6!   $! Описание
 69   $	" 265 6K   #   MaxWidth$
# 1024Q�6W   $   EditSettings$ 5*      6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  5+      %   TextWrapping$
% Wrap=�6+   5-        5.      $  KeyWords��6!   $!! Ключевые слова
 66   $	" 170 6N   $	# 200Q�6Z   $ 5/        50      $
% Wrap=�6+   52      53      54      55      