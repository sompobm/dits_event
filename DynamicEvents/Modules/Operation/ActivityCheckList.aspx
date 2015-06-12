<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityCheckList.aspx.cs" Inherits="Dynamic_Events.Modules.Operation.ActivityCheckList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceMng" runat="server">
        </ext:ResourceManager>
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:GridPanel ID="grdDetail" runat="server" Title="List" Margins="5 0 5 5"
                    Icon="Group" Region="Center" Frame="true">
                    <Store>
                        <ext:Store ID="storeDetail" runat="server">
                            <Proxy>
                                <ext:AjaxProxy >
                                    <Reader>
                                        <ext:JsonReader RootProperty="data" />
                                    </Reader>
                                </ext:AjaxProxy>
                            </Proxy>
                            <Sorters>
                                <ext:DataSorter Property="ActivityNo" />
                            </Sorters>
                            <%--OnReadData="StoreDriver_Refresh">--%>
                            <Model>
                                <ext:Model ID="Model" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="ActivityNo" />
                                        <ext:ModelField Name="ActivityName" />
                                        <ext:ModelField Name="ActivityDate" />
                                        <ext:ModelField Name="IsStatus" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn ID="RowNumbererColumn1" runat="server" Text="No" Width="60" Align="Center" />
                            <ext:Column ID="colActivityName" runat="server" DataIndex="ActivityName" Text="Activity Name" Flex="1" />
                            <ext:Column ID="colActivityDate" runat="server" DataIndex="ActivityDate" Text="Activity Date" Flex="1" />
                            <ext:CheckColumn ID="colIsStatus" runat="server" DataIndex="IsStatus" Text="Status" Flex="1" />
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
              
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
