   M S B A M L   `   `   `  ����H  DStoreWPFDXApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:StoreWPFDXApp.CommonStoreWPFDXApp.Common  5	   	   C&clr-namespace:StoreWPFDXApp.ViewModelsStoreWPFDXApp.ViewModels  5
   	   $    StoreWPFDXApp.Views.BrandsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aF 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   a ]DevExpress.Xpf.Grid.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Grid.v21.2.Extensions, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v21.2.Core, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid    5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   /common"clr-namespace:StoreWPFDXApp.Common  5	   	   7
ViewModels&clr-namespace:StoreWPFDXApp.ViewModels  5
   	     � Title$!  Торговые марки��5   	   $	��450��61   $	��315��6>    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � DataContext 5   	   #   StoreWPFDXApp.Common.DISource     Type$  ViewModels:BrandsViewModelL�.��5      � $	��300��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   (  "DevExpress.Xpf.Bars.ToolBarControl  ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. 5      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$  Редактировать 6       BarItemDisplayMode$ ContentAndGlyph=�5   ]   	   Command	 5   8   �� *View.Commands.EditFocusedRow+
 �� ElementName$

 grid��   Glyph 5       *  $DevExpress.Xpf.Core.DXImageExtension  *)'SvgImages/Icon Builder/Actions_Edit.svg+6]     5      $ Создать 6    $ ContentAndGlyph=�5   \   	 5   2   �� *View.Commands.AddNewRow+$

 grid�� 5         *(&SvgImages/Icon Builder/Actions_Add.svg+6\     5      $ Удалить 6    $ ContentAndGlyph=�5   _   	 5   2   �� * View.Commands.DeleteFocusedRow+$

 grid�� 5         *+)SvgImages/Icon Builder/Actions_Delete.svg+6_   5      %  DevExpress.Xpf.Grid.GridControl  5   
   -   5          Name$
 grid��5      $��1��6(   $	��300��65      View 5      #	  DevExpress.Xpf.Grid.TableView	  5       	  NewItemRowPosition$	 Top=�6     	  ShowUpdateRowButtons$ OnCellEditorOpen=�69   " 	  VerticalScrollbarVisibility$
 Auto=�6a    	  	AutoWidth . &
   DevExpress.Xpf.Grid.GridViewBase 
  ValidateRowCommand 5       �� *ValidateRowAsyncCommand+! 
  ValidateRowDeletionCommand 6W   �� *!ValidateRowDeletionAsyncCommand+)  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 5       -  'DevExpress.Xpf.Data.InfiniteAsyncSource  5!      +  %DevExpress.Xpf.Data.VirtualSourceBase   ElementType5   /StoreWPFDXApp.ViewModels.BrandGridItemViewModel"  6)      KeyProperty$
 UuId��6Y      FetchRowsCommand 6l   �� *FetchRowsCommand+   Columns. 5#      $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$
 Name��6   $  DevExpress.Xpf.Grid.BaseColumn   Header$ Наименование 6.   '    HorizontalHeaderContentAlignment$ Center=�6D      AllowEditing]	 YDevExpress.Data.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$
 True 6n      Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 150 6�   5$      5%      5&      