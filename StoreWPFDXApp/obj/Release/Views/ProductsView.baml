   M S B A M L   `   `   `  ���� H  DStoreWPFDXApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:StoreWPFDXApp.CommonStoreWPFDXApp.Common  C&clr-namespace:StoreWPFDXApp.ViewModelsStoreWPFDXApp.ViewModels  &     StoreWPFDXApp.Views.ProductsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aF 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     a ]DevExpress.Xpf.Grid.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Grid.v21.2.Extensions, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v21.2.Core, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid    ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  /common"clr-namespace:StoreWPFDXApp.Common  7
ViewModels&clr-namespace:StoreWPFDXApp.ViewModels  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors    � Title$  Товары��$	��550��$	��810�� � WindowStartupLocation$ CenterScreen=� � DataContext #   StoreWPFDXApp.Common.DISource     Type$" ViewModels:ProductsViewModelL�.���  � RowDefinitions �� $
��Auto ��� .+�(  "DevExpress.Xpf.Bars.ToolBarControl  ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Обновить    BarItemDisplayMode$ ContentAndGlyph=�   Command �� *!View.Commands.RefreshDataSource+	 �� ElementName$
	 grid��
   Glyph
 *  $DevExpress.Xpf.Core.DXImageExtension  *,*SvgImages/Icon Builder/Actions_Refresh.svg+  $  Редактировать $ ContentAndGlyph=� �� *View.Commands.EditFocusedRow+$
	 grid��
   *)'SvgImages/Icon Builder/Actions_Edit.svg+  $ Создать $ ContentAndGlyph=� �� *View.Commands.AddNewRow+$
	 grid��
   *(&SvgImages/Icon Builder/Actions_Add.svg+  $ Удалить $ ContentAndGlyph=� �� * View.Commands.DeleteFocusedRow+$
	 grid��
   *+)SvgImages/Icon Builder/Actions_Delete.svg+%  DevExpress.Xpf.Grid.GridControl  -     Name$
 grid��$��1��   View #	  DevExpress.Xpf.Grid.TableView	   	  NewItemRowPosition$	 Top=� 	  ShowUpdateRowButtons$ OnCellEditorOpen=�" 	  VerticalScrollbarVisibility$
 Auto=� 	  	AutoWidth . &
   DevExpress.Xpf.Grid.GridViewBase 
  ValidateRowCommand �� *ValidateRowAsyncCommand+! 
  ValidateRowDeletionCommand �� *!ValidateRowDeletionAsyncCommand+&   DevExpress.Xpf.Grid.DataViewBase   DataSourceRefreshCommand �� *DataSourceRefreshCommand+)  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource -  'DevExpress.Xpf.Data.InfiniteAsyncSource  +  %DevExpress.Xpf.Data.VirtualSourceBase   ElementType7   1StoreWPFDXApp.ViewModels.ProductGridItemViewModel"     KeyProperty$
 UuId��   FetchRowsCommand �� *FetchRowsCommand+   Columns. $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ Image��   AllowEditing]	 YDevExpress.Data.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$ False $  DevExpress.Xpf.Grid.BaseColumn   Header$ Фото    Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 150    CellTemplate �� .R��� .+�&   DevExpress.Xpf.Editors.ImageEdit    Name$ PART_Editor���� $��Выбрать������ *'%View.DataContext.SetImageAsyncCommand+���� *RowData.Row+  $
 Name��$
 True $ Наименование $	 150   $ Article��$
 True $ Артикул $	 100   $ CategoryUuId��$
 True $ Категория $	 150    EditSettings :  4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings  <  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase    DisplayMember$
  Name��!   ValueMember$
! UuId��"   ItemsSource" �� *
Categories+  $ 	BrandUuId��$
 True $! Торговая марка $	 150    $
  Name��$
! UuId��" �� *Brands+  $ Description��$
 True $ Описание $	 205 #   MaxWidth$
# 1024Q� 6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  $   TextWrapping$
$ Wrap=�  $ Price��$
 True $ Цена $ 50 