   M S B A M L   `   `   `  ����H  DStoreWPFDXApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:StoreWPFDXApp.CommonStoreWPFDXApp.Common  5	   	   C&clr-namespace:StoreWPFDXApp.ViewModelsStoreWPFDXApp.ViewModels  5
   	   &     StoreWPFDXApp.Views.ProductsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aF 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   a ]DevExpress.Xpf.Grid.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Grid.v21.2.Extensions, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v21.2.Core, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid    5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   /common"clr-namespace:StoreWPFDXApp.Common  5	   	   7
ViewModels&clr-namespace:StoreWPFDXApp.ViewModels  5
   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	     � Title$  Товары��5   	   $	��550��6)   $	��810��66    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5   	   #   StoreWPFDXApp.Common.DISource     Type$" ViewModels:ProductsViewModelL�.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   (  "DevExpress.Xpf.Bars.ToolBarControl  ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. 5      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Обновить 6       BarItemDisplayMode$ ContentAndGlyph=�5   `      Command 5   3   �� *!View.Commands.RefreshDataSource+	 �� ElementName$
	 grid��
   Glyph
 5       *  $DevExpress.Xpf.Core.DXImageExtension  *,*SvgImages/Icon Builder/Actions_Refresh.svg+6`     5      $  Редактировать 6    $ ContentAndGlyph=�5   ]    5   8   �� *View.Commands.EditFocusedRow+$
	 grid��
 5         *)'SvgImages/Icon Builder/Actions_Edit.svg+6]     5      $ Создать 6    $ ContentAndGlyph=�5   \    5   2   �� *View.Commands.AddNewRow+$
	 grid��
 5         *(&SvgImages/Icon Builder/Actions_Add.svg+6\     5      $ Удалить 6    $ ContentAndGlyph=�5   _    5   2   �� * View.Commands.DeleteFocusedRow+$
	 grid��
 5         *+)SvgImages/Icon Builder/Actions_Delete.svg+6_   5      %  DevExpress.Xpf.Grid.GridControl  5   
   -   5          Name$
 grid��5      $��1��6(      View 5      #	  DevExpress.Xpf.Grid.TableView	  5        	  NewItemRowPosition$	 Top=�6     	  ShowUpdateRowButtons$ OnCellEditorOpen=�69   " 	  VerticalScrollbarVisibility$
 Auto=�6a    	  	AutoWidth . &
   DevExpress.Xpf.Grid.GridViewBase 
  ValidateRowCommand 5!       �� *ValidateRowAsyncCommand+! 
  ValidateRowDeletionCommand 6W   �� *!ValidateRowDeletionAsyncCommand+&   DevExpress.Xpf.Grid.DataViewBase   DataSourceRefreshCommand 5"       �� *DataSourceRefreshCommand+)  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 5$      -  'DevExpress.Xpf.Data.InfiniteAsyncSource  5%      +  %DevExpress.Xpf.Data.VirtualSourceBase   ElementType7   1StoreWPFDXApp.ViewModels.ProductGridItemViewModel"  6)      KeyProperty$
 UuId��6[      FetchRowsCommand 6n   �� *FetchRowsCommand+   Columns. 5'      $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ Image��6      AllowEditing]	 YDevExpress.Data.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$ False 6/   $  DevExpress.Xpf.Grid.BaseColumn   Header$ Фото 6D      Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 150 6R      CellTemplate 5(      �� 5)      .R�5*      �� .+�5+      &   DevExpress.Xpf.Editors.ImageEdit    Name$ PART_Editor��6,   �� 5,      $��Выбрать��6%   ��67   �� *'%View.DataContext.SetImageAsyncCommand+��5-   %   �� *RowData.Row+5.      5/      51        52      $
 Name��6   $
 True 6.   $ Наименование 6B   $	 150 6X     53      $ Article��6   $
 True 61   $ Артикул 6E   $	 100 6V     54      $ CategoryUuId��6   $
 True 66   $ Категория 6J   $	 150 6]      EditSettings 55      :  4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings  56      <  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase    DisplayMember$
  Name��6/   !   ValueMember$
! UuId��6D   "   ItemsSource" 6W   �� *
Categories+58        59      $ 	BrandUuId��6   $
 True 63   $! Торговая марка 6G   $	 150 6_    5:        5;      $
  Name��6/   $
! UuId��6D   " 6W   �� *Brands+5=        5>      $ Description��6   $
 True 65   $ Описание 6I   $	 205 6[   #   MaxWidth$
# 1024Q�6g    5?      6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  5@      $   TextWrapping$
$ Wrap=�6+   5B        5C      $ Price��6   $
 True 6/   $ Цена 6C   $ 50 6Q   5D      5E      5F      