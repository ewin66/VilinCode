<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionCluster.aspx.cs" Inherits="Vilin.Web.SessionCluster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>



        <table class="wikitable">
            <tbody>
                <tr>
                    <th width="120">國家地區
                    </th>
                    <th width="90">時區
                    </th>
                    <th width="90">夏令時間
                    </th>
                    <th>備註
                    </th>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8F%B0%E6%BE%8E%E9%87%91%E9%A6%AC" title="台澎金馬" class="mw-redirect">台澎金馬</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%B8%AD%E5%9C%8B" title="中國">中國</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%99%E6%B8%AF" title="香港">香港</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%BE%B3%E9%96%80" title="澳門">澳門</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%97%A5%E6%9C%AC" title="日本">日本</a>
                    </td>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%9F%93%E5%9C%8B" title="韓國">韓國</a>
                    </td>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%9C%9D%E9%AE%AE" title="朝鮮">朝鮮</a>
                    </td>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="2"><a href="/guide/index.php/%E8%92%99%E5%8F%A4%E5%9C%8B" title="蒙古國">蒙古國</a>
                    </td>
                    <td style="text-align: center;">UTC +7:00
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td>科布多省、烏布蘇省、巴彥烏列蓋省
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%B6%8A%E5%8D%97" title="越南">越南</a>
                    </td>
                    <td style="text-align: center;">UTC +7:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%9F%AC%E5%9F%94%E5%AF%A8" title="柬埔寨" class="mw-redirect">柬埔寨</a>
                    </td>
                    <td style="text-align: center;">UTC +7:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%AF%AE%E5%9C%8B" title="寮國">寮國</a>
                    </td>
                    <td style="text-align: center;">UTC +7:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%B7%AC%E7%94%B8" title="緬甸">緬甸</a>
                    </td>
                    <td style="text-align: center;">UTC +6:30
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B3%B0%E5%9C%8B" title="泰國">泰國</a>
                    </td>
                    <td style="text-align: center;">UTC +7:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E4%BE%86%E8%A5%BF%E4%BA%9E" title="馬來西亞">馬來西亞</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%96%B0%E5%8A%A0%E5%9D%A1" title="新加坡">新加坡</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B1%B6%E8%90%8A" title="汶萊">汶萊</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="3"><a href="/guide/index.php/%E5%8D%B0%E5%B0%BC" title="印尼">印尼</a>
                    </td>
                    <td style="text-align: center;">UTC +7:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>西部 (蘇門達臘、爪哇、西加里曼丹、中加里曼丹)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>中部 (蘇拉威西、巴里島、西努沙登加拉、東努沙登加拉、東加里曼丹、南加里曼丹)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>東部 (馬魯古、北馬魯古、巴布亞、西巴布亞)
                    </td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%9D%B1%E5%B8%9D%E6%B1%B6" title="東帝汶">東帝汶</a>
                    </td>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%8F%B2%E5%BE%8B%E8%B3%93" title="菲律賓">菲律賓</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8D%B0%E5%BA%A6" title="印度">印度</a>
                    </td>
                    <td style="text-align: center;">UTC +5:30
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%AD%9F%E5%8A%A0%E6%8B%89" title="孟加拉">孟加拉</a>
                    </td>
                    <td style="text-align: center;">UTC +6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%B8%8D%E4%B8%B9" title="不丹">不丹</a>
                    </td>
                    <td style="text-align: center;">UTC +6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B0%BC%E6%B3%8A%E7%88%BE" title="尼泊爾">尼泊爾</a>
                    </td>
                    <td style="text-align: center;">UTC +5:45
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%96%AF%E9%87%8C%E8%98%AD%E5%8D%A1" title="斯里蘭卡">斯里蘭卡</a>
                    </td>
                    <td style="text-align: center;">UTC +5:30
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B7%B4%E5%9F%BA%E6%96%AF%E5%9D%A6" title="巴基斯坦">巴基斯坦</a>
                    </td>
                    <td style="text-align: center;">UTC +5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E7%88%BE%E5%9C%B0%E5%A4%AB" title="馬爾地夫">馬爾地夫</a>
                    </td>
                    <td style="text-align: center;">UTC +5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%98%BF%E5%AF%8C%E6%B1%97" title="阿富汗">阿富汗</a>
                    </td>
                    <td style="text-align: center;">UTC +4:30
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="2"><a href="/guide/index.php/%E5%93%88%E8%96%A9%E5%85%8B" title="哈薩克">哈薩克</a>
                    </td>
                    <td style="text-align: center;">UTC +5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>西部
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>東部
                    </td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A1%94%E5%90%89%E5%85%8B" title="塔吉克">塔吉克</a>
                    </td>
                    <td style="text-align: center;">UTC +5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%9C%9F%E5%BA%AB%E6%9B%BC" title="土庫曼">土庫曼</a>
                    </td>
                    <td style="text-align: center;">UTC +5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%90%89%E7%88%BE%E5%90%89%E6%96%AF" title="吉爾吉斯">吉爾吉斯</a>
                    </td>
                    <td style="text-align: center;">UTC +6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%83%8F%E8%8C%B2%E5%88%A5%E5%85%8B" title="烏茲別克">烏茲別克</a>
                    </td>
                    <td style="text-align: center;">UTC +5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%BA%9E%E5%A1%9E%E6%8B%9C%E7%84%B6" title="亞塞拜然" class="mw-redirect">亞塞拜然</a>
                    </td>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td style="text-align: center;">UTC +5:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%96%AC%E6%B2%BB%E4%BA%9E" title="喬治亞">喬治亞</a>
                    </td>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%BA%9E%E7%BE%8E%E5%B0%BC%E4%BA%9E" title="亞美尼亞">亞美尼亞</a>
                    </td>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td style="text-align: center;">UTC +5:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%BC%8A%E6%9C%97" title="伊朗">伊朗</a>
                    </td>
                    <td style="text-align: center;">UTC +3:30
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%BC%8A%E6%8B%89%E5%85%8B" title="伊拉克">伊拉克</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%A7%91%E5%A8%81%E7%89%B9" title="科威特">科威特</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B2%99%E7%83%8F%E5%9C%B0%E9%98%BF%E6%8B%89%E4%BC%AF" title="沙烏地阿拉伯">沙烏地阿拉伯</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B7%B4%E6%9E%97" title="巴林">巴林</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8D%A1%E9%81%94" title="卡達">卡達</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%98%BF%E6%8B%89%E4%BC%AF%E8%81%AF%E5%90%88%E5%A4%A7%E5%85%AC%E5%9C%8B" title="阿拉伯聯合大公國">阿拉伯聯合大公國</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%98%BF%E6%9B%BC" title="阿曼">阿曼</a>
                    </td>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%91%89%E9%96%80" title="葉門">葉門</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%BB%A5%E8%89%B2%E5%88%97" title="以色列">以色列</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B7%B4%E5%8B%92%E6%96%AF%E5%9D%A6" title="巴勒斯坦">巴勒斯坦</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%95%98%E5%88%A9%E4%BA%9E" title="敘利亞">敘利亞</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%BB%8E%E5%B7%B4%E5%AB%A9" title="黎巴嫩">黎巴嫩</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%B4%84%E6%97%A6" title="約旦">約旦</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;"></td>
                </tr>
            </tbody>
        </table>

        <table class="wikitable">
            <tbody>
                <tr>
                    <th width="120">國家地區
                    </th>
                    <th width="90">時區
                    </th>
                    <th width="90">夏令時間
                    </th>
                    <th>備註
                    </th>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%8B%B1%E5%9C%8B" title="英國">英國</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php?title=%E6%9B%BC%E5%B3%B6&amp;action=edit&amp;redlink=1" class="new" title="曼島 (頁面不存在)">曼島</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>海峽群島
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%9B%B4%E5%B8%83%E7%BE%85%E9%99%80" title="直布羅陀">直布羅陀</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%84%9B%E7%88%BE%E8%98%AD" title="愛爾蘭">愛爾蘭</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B3%95%E5%9C%8B" title="法國">法國</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%91%A9%E7%B4%8D%E5%93%A5" title="摩納哥">摩納哥</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%8D%B7%E8%98%AD" title="荷蘭">荷蘭</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%AF%94%E5%88%A9%E6%99%82" title="比利時">比利時</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%A5%BF%E7%8F%AD%E7%89%99" title="西班牙">西班牙</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%AE%89%E9%81%93%E7%88%BE" title="安道爾">安道爾</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%91%A1%E8%90%84%E7%89%99" title="葡萄牙">葡萄牙</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%BA%9E%E8%BF%B0%E7%BE%A4%E5%B3%B6" title="亞述群島">亞述群島</a>
                    </td>
                    <td style="text-align: center;">UTC -1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%BE%B7%E5%9C%8B" title="德國">德國</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%9B%A7%E6%A3%AE%E5%A0%A1" title="盧森堡">盧森堡</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%91%9E%E5%A3%AB" title="瑞士">瑞士</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%88%97%E6%94%AF%E6%95%A6%E5%A3%AB%E7%99%BB" title="列支敦士登">列支敦士登</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A5%A7%E5%9C%B0%E5%88%A9" title="奧地利">奧地利</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B3%A2%E8%98%AD" title="波蘭">波蘭</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%8D%B7%E5%85%8B" title="捷克">捷克</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%96%AF%E6%B4%9B%E4%BC%90%E5%85%8B" title="斯洛伐克">斯洛伐克</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8C%88%E7%89%99%E5%88%A9" title="匈牙利">匈牙利</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%BE%A9%E5%A4%A7%E5%88%A9" title="義大利">義大利</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%81%96%E9%A6%AC%E5%88%A9%E8%AB%BE" title="聖馬利諾">聖馬利諾</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%A2%B5%E8%AB%A6%E5%B2%A1" title="梵諦岡">梵諦岡</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E7%88%BE%E4%BB%96" title="馬爾他">馬爾他</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%B3%BD%E6%99%AE%E5%8B%92%E6%96%AF" title="賽普勒斯">賽普勒斯</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8C%97%E8%B3%BD%E6%99%AE%E5%8B%92%E6%96%AF" title="北賽普勒斯">北賽普勒斯</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B8%8C%E8%87%98" title="希臘">希臘</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%96%AF%E6%B4%9B%E7%B6%AD%E5%B0%BC%E4%BA%9E" title="斯洛維尼亞">斯洛維尼亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%85%8B%E7%BE%85%E5%9F%83%E8%A5%BF%E4%BA%9E" title="克羅埃西亞">克羅埃西亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%98%BF%E7%88%BE%E5%B7%B4%E5%B0%BC%E4%BA%9E" title="阿爾巴尼亞">阿爾巴尼亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B3%A2%E5%A3%AB%E5%B0%BC%E4%BA%9E%E8%B5%AB%E5%A1%9E%E5%93%A5%E7%B6%AD%E7%B4%8D" title="波士尼亞赫塞哥維納">波士尼亞赫塞哥維納</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A1%9E%E7%88%BE%E7%B6%AD%E4%BA%9E" title="塞爾維亞" class="mw-redirect">塞爾維亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%92%99%E7%89%B9%E5%85%A7%E5%93%A5%E7%BE%85" title="蒙特內哥羅">蒙特內哥羅</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E5%85%B6%E9%A0%93" title="馬其頓">馬其頓</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%9C%9F%E8%80%B3%E5%85%B6" title="土耳其">土耳其</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%B8%B9%E9%BA%A5" title="丹麥">丹麥</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B3%95%E7%BE%85%E7%BE%A4%E5%B3%B6" title="法羅群島">法羅群島</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%8A%AC%E8%98%AD" title="芬蘭">芬蘭</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%91%9E%E5%85%B8" title="瑞典">瑞典</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%8C%AA%E5%A8%81" title="挪威">挪威</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%86%B0%E5%B3%B6" title="冰島">冰島</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%AB%8B%E9%99%B6%E5%AE%9B" title="立陶宛">立陶宛</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%8B%89%E8%84%AB%E7%B6%AD%E4%BA%9E" title="拉脫維亞" class="mw-redirect">拉脫維亞</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%84%9B%E6%B2%99%E5%B0%BC%E4%BA%9E" title="愛沙尼亞">愛沙尼亞</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%99%BD%E4%BF%84%E7%BE%85%E6%96%AF" title="白俄羅斯">白俄羅斯</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%83%8F%E5%85%8B%E8%98%AD" title="烏克蘭">烏克蘭</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%91%A9%E7%88%BE%E5%A4%9A%E7%93%A6" title="摩爾多瓦">摩爾多瓦</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%BE%85%E9%A6%AC%E5%B0%BC%E4%BA%9E" title="羅馬尼亞">羅馬尼亞</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%BF%9D%E5%8A%A0%E5%88%A9%E4%BA%9E" title="保加利亞">保加利亞</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="11"><a href="/guide/index.php/%E4%BF%84%E7%BE%85%E6%96%AF" title="俄羅斯">俄羅斯</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>加里寧格勒時間 (加里寧格勒州)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>莫斯科時間 (莫斯科、聖彼得堡)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>葉卡特里堡時間 (葉卡特里堡時間)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +7:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>鄂木斯克時間 (鄂木斯克、新西伯利亞)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>克拉斯諾雅斯克時間 (克拉斯諾雅斯克)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>伊爾庫茲克時間 (伊爾庫茲克)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +10:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>雅庫茲克時間 (雅庫茲克、赤塔)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>伏拉迪沃斯托克時間 (哈巴羅夫斯克、伏拉迪沃斯托克、庫頁島)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +12:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>馬加丹時間 (馬加丹、堪察加)
                    </td>
                </tr>
            </tbody>
        </table>

        <table class="wikitable">
            <tbody>
                <tr>
                    <th width="120">國家地區
                    </th>
                    <th width="90">時區
                    </th>
                    <th width="90">夏令時間
                    </th>
                    <th>備註
                    </th>
                </tr>
                <tr>
                    <td rowspan="6"><a href="/guide/index.php/%E5%8A%A0%E6%8B%BF%E5%A4%A7" title="加拿大">加拿大</a>
                    </td>
                    <td style="text-align: center;">UTC -8:00
                    </td>
                    <td style="text-align: center;">UTC -7:00
                    </td>
                    <td>太平洋時間 (英屬哥倫比亞省西部、西北地方Tungsten、育空地區)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -7:00
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td>山區時間 (亞伯達省、英屬哥倫比亞省東部、西北地方、努勒維特地區西部、薩克其萬省)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td>中部時間 (曼尼托巴省、努勒維特區中部、努勒維特區東部, 安大略省西部, 薩克其萬省)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td>東部時間 (努勒維特區東部、安大略省東部、魁北克省)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td>大西洋時間 (拉布拉多、新伯倫瑞克省、新斯科細亞、愛德華王子島省、魁北克省東部)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -3:30
                    </td>
                    <td style="text-align: center;">UTC -2:30
                    </td>
                    <td>紐芬蘭時間 (紐芬蘭)
                    </td>
                </tr>
                <tr>
                    <td rowspan="4"><a href="/guide/index.php/%E7%BE%8E%E5%9C%8B" title="美國">美國</a>
                    </td>
                    <td style="text-align: center;">UTC -8:00
                    </td>
                    <td style="text-align: center;">UTC -7:00
                    </td>
                    <td>太平洋時間 (加州、愛德荷州、內華達州、奧勒岡州、華盛頓州)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -7:00
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td>山區時間 (亞利桑那州、科羅拉多州、愛德荷州南部、蒙大拿州、內布拉斯加州西部、新墨西哥州、北達科他州西部、南達科他州、猶他州、懷俄明州)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td>中部時間 (阿拉巴馬州、阿肯色州、伊利諾斯州、愛阿華州、堪薩斯州、肯塔基州西部、路易西安納州、明尼蘇達州、密西西比州、密蘇里州、內布拉斯加州東部、北達科他州、奧克拉荷馬州、南達科他州東部、田納西州中西部、德克薩斯州、威斯康辛州)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td>東部時間 (康乃狄克州、德拉瓦州、華盛頓特區、佛羅里達州、喬治亞州、印第安納州、肯塔基州東部、緬因州、馬里蘭州、麻薩諸塞州、密西根州、新罕布夏州、紐澤西州、紐約州、北卡羅來納州、俄亥俄州、賓夕法尼亞州、羅德艾蘭州、南卡羅萊那州、田納西州東部、佛蒙特州、維吉尼亞州、西維吉尼亞州)
                    </td>
                </tr>
                <tr>
                    <td>美國<a href="/guide/index.php/%E9%98%BF%E6%8B%89%E6%96%AF%E5%8A%A0%E5%B7%9E" title="阿拉斯加州">阿拉斯加州</a>
                    </td>
                    <td style="text-align: center;">UTC -9:00
                    </td>
                    <td style="text-align: center;">UTC -8:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="3"><a href="/guide/index.php/%E5%A2%A8%E8%A5%BF%E5%93%A5" title="墨西哥">墨西哥</a>
                    </td>
                    <td style="text-align: center;">UTC -8:00
                    </td>
                    <td style="text-align: center;">UTC -7:00
                    </td>
                    <td>西北區 (下加利福尼亞州)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -7:00
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td>太平洋區 (南下加利福尼亞州、奇瓦瓦州、納亞里特州、錫那羅亞州、索諾拉州)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td>中央區
                    </td>
                </tr>
                <tr>
                    <td rowspan="4">丹麥 <a href="/guide/index.php/%E6%A0%BC%E9%99%B5%E8%98%AD" title="格陵蘭">格陵蘭</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td>西北部的 Qaanaaq 地區
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td style="text-align: center;">UTC -2:00
                    </td>
                    <td>主要區域
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -1:00
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td>東部的 Ittoqqortoormiit (Scoresbysund) 地區
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td>東北部的 Danmarkshavn 地區
                    </td>
                </tr>
                <tr>
                    <td>法國 聖皮埃爾和密克隆群島
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td style="text-align: center;">UTC -2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%B2%9D%E9%87%8C%E6%96%AF" title="貝里斯">貝里斯</a>
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%93%9C%E5%9C%B0%E9%A6%AC%E6%8B%89" title="瓜地馬拉">瓜地馬拉</a>
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%96%A9%E7%88%BE%E7%93%A6%E5%A4%9A" title="薩爾瓦多">薩爾瓦多</a>
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%AE%8F%E9%83%BD%E6%8B%89%E6%96%AF" title="宏都拉斯">宏都拉斯</a>
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B0%BC%E5%8A%A0%E6%8B%89%E7%93%9C" title="尼加拉瓜">尼加拉瓜</a>
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%93%A5%E6%96%AF%E5%A4%A7%E9%BB%8E%E5%8A%A0" title="哥斯大黎加">哥斯大黎加</a>
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B7%B4%E6%8B%BF%E9%A6%AC" title="巴拿馬">巴拿馬</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%99%BE%E6%85%95%E9%81%94" title="百慕達">百慕達</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B7%B4%E5%93%88%E9%A6%AC" title="巴哈馬">巴哈馬</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8F%A4%E5%B7%B4" title="古巴">古巴</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%89%99%E8%B2%B7%E5%8A%A0" title="牙買加">牙買加</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B5%B7%E5%9C%B0" title="海地">海地</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A4%9A%E6%98%8E%E5%B0%BC%E5%8A%A0" title="多明尼加">多明尼加</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B3%A2%E5%A4%9A%E9%BB%8E%E5%90%84" title="波多黎各">波多黎各</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%96%8B%E6%9B%BC%E7%BE%A4%E5%B3%B6" title="開曼群島">開曼群島</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>特克斯和凱科斯群島
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%81%96%E5%85%8B%E9%87%8C%E6%96%AF%E5%A4%9A%E7%A6%8F" title="聖克里斯多福">聖克里斯多福</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%AE%89%E5%9C%B0%E5%8D%A1%E5%8F%8A%E5%B7%B4%E5%B8%83%E9%81%94" title="安地卡及巴布達">安地卡及巴布達</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A4%9A%E7%B1%B3%E5%B0%BC%E5%85%8B" title="多米尼克">多米尼克</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%BE%8E%E5%B1%AC%E7%B6%AD%E4%BA%AC%E7%BE%A4%E5%B3%B6" title="美屬維京群島">美屬維京群島</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%8B%B1%E5%B1%AC%E7%B6%AD%E4%BA%AC%E7%BE%A4%E5%B3%B6" title="英屬維京群島">英屬維京群島</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%AE%89%E5%9C%AD%E6%8B%89" title="安圭拉">安圭拉</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%93%9C%E5%BE%B7%E7%BE%85%E6%99%AE" title="瓜德羅普">瓜德羅普</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%81%96%E9%9C%B2%E8%A5%BF%E4%BA%9E" title="聖露西亞">聖露西亞</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B7%B4%E8%B2%9D%E5%A4%9A" title="巴貝多">巴貝多</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%81%96%E6%96%87%E6%A3%AE%E5%8F%8A%E6%A0%BC%E7%91%9E%E9%82%A3%E4%B8%81" title="聖文森及格瑞那丁">聖文森及格瑞那丁</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%A0%BC%E7%91%9E%E9%82%A3%E9%81%94" title="格瑞那達">格瑞那達</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8D%83%E9%87%8C%E9%81%94%E5%8F%8A%E6%89%98%E8%B2%9D%E5%93%A5" title="千里達及托貝哥">千里達及托貝哥</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E6%8F%90%E5%B0%BC%E5%85%8B" title="馬提尼克">馬提尼克</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%98%BF%E9%AD%AF%E5%B7%B4" title="阿魯巴">阿魯巴</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%8D%B7%E5%B1%AC%E5%AE%89%E7%9A%84%E5%88%97%E6%96%AF" title="荷屬安的列斯">荷屬安的列斯</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>蒙特塞拉特
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%93%A5%E5%80%AB%E6%AF%94%E4%BA%9E" title="哥倫比亞">哥倫比亞</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A7%94%E5%85%A7%E7%91%9E%E6%8B%89" title="委內瑞拉">委內瑞拉</a>
                    </td>
                    <td style="text-align: center;">UTC -4:30
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%8E%BB%E5%88%A9%E7%B6%AD%E4%BA%9E" title="玻利維亞">玻利維亞</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%93%8B%E4%BA%9E%E7%B4%8D" title="蓋亞納">蓋亞納</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8E%84%E7%93%9C%E5%A4%9A" title="厄瓜多">厄瓜多</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B7%B4%E6%8B%89%E5%9C%AD" title="巴拉圭">巴拉圭</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%98%87%E5%88%A9%E5%8D%97" title="蘇利南">蘇利南</a>
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%83%8F%E6%8B%89%E5%9C%AD" title="烏拉圭">烏拉圭</a>
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td style="text-align: center;">UTC -2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%A7%98%E9%AD%AF" title="秘魯">秘魯</a>
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="3"><a href="/guide/index.php/%E5%B7%B4%E8%A5%BF" title="巴西">巴西</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td>巴西利亞時間 -1 (亞馬遜雨林區)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td style="text-align: center;">UTC -2:00
                    </td>
                    <td>巴西利亞時間 (巴西利亞、聖保羅、里約)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -2:00
                    </td>
                    <td style="text-align: center;">UTC -1:00
                    </td>
                    <td>巴西利亞時間 +1 (東岸島嶼)
                    </td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%99%BA%E5%88%A9" title="智利">智利</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%98%BF%E6%A0%B9%E5%BB%B7" title="阿根廷">阿根廷</a>
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B3%95%E5%B1%AC%E5%9C%AD%E4%BA%9E%E9%82%A3" title="法屬圭亞那">法屬圭亞那</a>
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%A6%8F%E5%85%8B%E8%98%AD%E7%BE%A4%E5%B3%B6" title="福克蘭群島">福克蘭群島</a>
                    </td>
                    <td style="text-align: center;">UTC -4:00
                    </td>
                    <td style="text-align: center;">UTC -3:00
                    </td>
                    <td style="text-align: center;"></td>
                </tr>
            </tbody>
        </table>

        <table class="wikitable">
            <tbody>
                <tr>
                    <th width="120">國家地區
                    </th>
                    <th width="90">時區
                    </th>
                    <th width="100">夏令時間
                    </th>
                    <th>備註
                    </th>
                </tr>
                <tr>
                    <td rowspan="3"><a href="/guide/index.php/%E6%BE%B3%E6%B4%B2" title="澳洲">澳洲</a>
                    </td>
                    <td style="text-align: center;">UTC +8:00
                    </td>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td>西部時間 (西澳大利亞州)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +9:30
                    </td>
                    <td style="text-align: center;">UTC +10:30<br>
                        (僅南澳大利亞州)
                    </td>
                    <td>中部時間 (南澳大利亞州、北領地)
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +10:00
                    </td>
                    <td style="text-align: center;">UTC +11:00<br>
                        (除昆士蘭州)
                    </td>
                    <td>東部時間 (昆士蘭州、新南威爾斯州、維多利亞州、塔斯馬尼亞州)
                    </td>
                </tr>
                <tr>
                    <td>諾福克島
                    </td>
                    <td style="text-align: center;">UTC +11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%81%96%E8%AA%95%E5%B3%B6" title="聖誕島">聖誕島</a>
                    </td>
                    <td style="text-align: center;">UTC +7:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>科科斯群島/基林群島
                    </td>
                    <td style="text-align: center;">UTC +6:30
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%B4%90%E8%A5%BF%E8%98%AD" title="紐西蘭">紐西蘭</a>
                    </td>
                    <td style="text-align: center;">UTC +12:00
                    </td>
                    <td style="text-align: center;">UTC +13:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>紐西蘭 托克勞群島
                    </td>
                    <td style="text-align: center;">UTC -11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B8%9B%E7%90%89" title="帛琉">帛琉</a>
                    </td>
                    <td style="text-align: center;">UTC +9:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E7%B4%B9%E7%88%BE%E7%BE%A4%E5%B3%B6" title="馬紹爾群島">馬紹爾群島</a>
                    </td>
                    <td style="text-align: center;">UTC +12:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%AB%BE%E9%AD%AF" title="諾魯">諾魯</a>
                    </td>
                    <td style="text-align: center;">UTC +12:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="2"><a href="/guide/index.php/%E5%AF%86%E5%85%8B%E7%BE%85%E5%B0%BC%E8%A5%BF%E4%BA%9E" title="密克羅尼西亞">密克羅尼西亞</a>
                    </td>
                    <td style="text-align: center;">UTC +10:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>雅浦、丘克
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>波納佩、科斯雷
                    </td>
                </tr>
                <tr>
                    <td rowspan="3"><a href="/guide/index.php/%E5%90%89%E9%87%8C%E5%B7%B4%E6%96%AF" title="吉里巴斯">吉里巴斯</a>
                    </td>
                    <td style="text-align: center;">UTC +12:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>吉爾伯特群島
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +13:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>鳳凰城群島
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +14:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>萊恩群島
                    </td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%97%9C%E5%B3%B6" title="關島">關島</a>
                    </td>
                    <td style="text-align: center;">UTC +10:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8C%97%E9%A6%AC%E9%87%8C%E4%BA%9E%E7%B4%8D%E7%BE%A4%E5%B3%B6" title="北馬里亞納群島">北馬里亞納群島</a>
                    </td>
                    <td style="text-align: center;">UTC +10:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%89%80%E7%BE%85%E9%96%80%E7%BE%A4%E5%B3%B6" title="所羅門群島">所羅門群島</a>
                    </td>
                    <td style="text-align: center;">UTC +11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%90%AC%E9%82%A3%E6%9D%9C" title="萬那杜">萬那杜</a>
                    </td>
                    <td style="text-align: center;">UTC +11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%96%90%E6%BF%9F" title="斐濟">斐濟</a>
                    </td>
                    <td style="text-align: center;">UTC +12:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B7%B4%E5%B8%83%E4%BA%9E%E6%96%B0%E5%B9%BE%E5%85%A7%E4%BA%9E" title="巴布亞新幾內亞">巴布亞新幾內亞</a>
                    </td>
                    <td style="text-align: center;">UTC +10:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%96%B0%E5%96%80%E9%87%8C%E5%A4%9A%E5%B0%BC%E4%BA%9E" title="新喀里多尼亞">新喀里多尼亞</a>
                    </td>
                    <td style="text-align: center;">UTC +11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>瓦利斯和富圖納群島
                    </td>
                    <td style="text-align: center;">UTC +12:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>紐埃
                    </td>
                    <td style="text-align: center;">UTC -11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%9D%B1%E5%8A%A0" title="東加">東加</a>
                    </td>
                    <td style="text-align: center;">UTC +13:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%96%A9%E6%91%A9%E4%BA%9E" title="薩摩亞">薩摩亞</a>
                    </td>
                    <td style="text-align: center;">UTC +13:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%BE%8E%E5%B1%AC%E8%96%A9%E6%91%A9%E4%BA%9E" title="美屬薩摩亞">美屬薩摩亞</a>
                    </td>
                    <td style="text-align: center;">UTC -11:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%90%90%E7%93%A6%E9%AD%AF" title="吐瓦魯">吐瓦魯</a>
                    </td>
                    <td style="text-align: center;">UTC +12:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%BA%AB%E5%85%8B%E7%BE%A4%E5%B3%B6" title="庫克群島">庫克群島</a>
                    </td>
                    <td style="text-align: center;">UTC -10:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>美國 <a href="/guide/index.php/%E5%A4%8F%E5%A8%81%E5%A4%B7" title="夏威夷" class="mw-redirect">夏威夷</a>
                    </td>
                    <td style="text-align: center;">UTC -10:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="3"><a href="/guide/index.php/%E6%B3%95%E5%B1%AC%E7%8E%BB%E9%87%8C%E5%B0%BC%E8%A5%BF%E4%BA%9E" title="法屬玻里尼西亞">法屬玻里尼西亞</a>
                    </td>
                    <td style="text-align: center;">UTC -10:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>社會群島、土阿莫土群島、南方群島
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -9:30
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>馬克薩斯群島
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC -9:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>甘比爾群島
                    </td>
                </tr>
                <tr>
                    <td>智利 <a href="/guide/index.php/%E5%BE%A9%E6%B4%BB%E7%AF%80%E5%B3%B6" title="復活節島">復活節島</a>
                    </td>
                    <td style="text-align: center;">UTC -6:00
                    </td>
                    <td style="text-align: center;">UTC -5:00
                    </td>
                    <td></td>
                </tr>
            </tbody>
        </table>

        <table class="wikitable">
            <tbody>
                <tr>
                    <th width="120">國家地區
                    </th>
                    <th width="90">時區
                    </th>
                    <th width="90">夏令時間
                    </th>
                    <th>備註
                    </th>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%9F%83%E5%8F%8A" title="埃及">埃及</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%98%87%E4%B8%B9" title="蘇丹">蘇丹</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%91%A9%E6%B4%9B%E5%93%A5" title="摩洛哥">摩洛哥</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%A5%BF%E6%92%92%E5%93%88%E6%8B%89" title="西撒哈拉">西撒哈拉</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%98%BF%E7%88%BE%E5%8F%8A%E5%88%A9%E4%BA%9E" title="阿爾及利亞">阿爾及利亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%AA%81%E5%B0%BC%E8%A5%BF%E4%BA%9E" title="突尼西亞">突尼西亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%88%A9%E6%AF%94%E4%BA%9E" title="利比亞">利比亞</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>西班牙 <a href="/guide/index.php/%E5%8A%A0%E9%82%A3%E5%88%A9%E7%BE%A4%E5%B3%B6" title="加那利群島">加那利群島</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8E%84%E5%88%A9%E5%9E%82%E4%BA%9E" title="厄利垂亞">厄利垂亞</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%A1%A3%E7%B4%A2%E6%AF%94%E4%BA%9E" title="衣索比亞">衣索比亞</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%B4%A2%E9%A6%AC%E5%88%A9%E4%BA%9E" title="索馬利亞">索馬利亞</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%90%89%E5%B8%83%E6%8F%90" title="吉布提">吉布提</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%82%AF%E4%BA%9E" title="肯亞">肯亞</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%83%8F%E5%B9%B2%E9%81%94" title="烏干達">烏干達</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%9B%A7%E5%AE%89%E9%81%94" title="盧安達">盧安達</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%92%B2%E9%9A%86%E5%9C%B0" title="蒲隆地" class="mw-redirect">蒲隆地</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%9D%A6%E5%B0%9A%E5%B0%BC%E4%BA%9E" title="坦尚尼亞">坦尚尼亞</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E6%8B%89%E5%A8%81" title="馬拉威">馬拉威</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%8E%AB%E4%B8%89%E6%AF%94%E5%85%8B" title="莫三比克">莫三比克</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%91%9B%E6%91%A9" title="葛摩">葛摩</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E9%81%94%E5%8A%A0%E6%96%AF%E5%8A%A0" title="馬達加斯加">馬達加斯加</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A1%9E%E5%B8%AD%E7%88%BE" title="塞席爾">塞席爾</a>
                    </td>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%A8%A1%E9%87%8C%E8%A5%BF%E6%96%AF" title="模里西斯">模里西斯</a>
                    </td>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%95%99%E5%B0%BC%E6%97%BA" title="留尼旺">留尼旺</a>
                    </td>
                    <td style="text-align: center;">UTC +4:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E7%B4%84%E7%89%B9" title="馬約特">馬約特</a>
                    </td>
                    <td style="text-align: center;">UTC +3:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%BD%9B%E5%BE%B7%E8%A7%92" title="佛德角">佛德角</a>
                    </td>
                    <td style="text-align: center;">UTC -1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A1%9E%E5%85%A7%E5%8A%A0%E7%88%BE" title="塞內加爾">塞內加爾</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%94%98%E6%AF%94%E4%BA%9E" title="甘比亞">甘比亞</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B9%BE%E5%85%A7%E4%BA%9E%E5%85%B1%E5%92%8C%E5%9C%8B" title="幾內亞共和國">幾內亞共和國</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B9%BE%E5%85%A7%E4%BA%9E%E6%AF%94%E7%B4%A2%E5%85%B1%E5%92%8C%E5%9C%8B" title="幾內亞比索共和國">幾內亞比索共和國</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%B3%B4%E6%AF%94%E7%91%9E%E4%BA%9E" title="賴比瑞亞">賴比瑞亞</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%8D%85%E5%AD%90%E5%B1%B1" title="獅子山">獅子山</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%8C%85%E5%88%A9%E5%A1%94%E5%B0%BC%E4%BA%9E" title="茅利塔尼亞">茅利塔尼亞</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E9%A6%AC%E5%88%A9" title="馬利">馬利</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%A7%91%E7%89%B9%E8%BF%AA%E7%93%A6" title="科特迪瓦">科特迪瓦</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B8%83%E5%90%89%E7%B4%8D%E6%B3%95%E7%B4%A2" title="布吉納法索">布吉納法索</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B0%BC%E6%97%A5" title="尼日">尼日</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A4%9A%E5%93%A5" title="多哥">多哥</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%B2%9D%E5%8D%97" title="貝南">貝南</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%BF%A6%E7%B4%8D" title="迦納">迦納</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%A5%88%E5%8F%8A%E5%88%A9%E4%BA%9E" title="奈及利亞">奈及利亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%81%96%E5%A4%9A%E7%BE%8E%E6%99%AE%E6%9E%97%E8%A5%BF%E6%AF%94" title="聖多美普林西比">聖多美普林西比</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%AE%89%E5%93%A5%E6%8B%89" title="安哥拉">安哥拉</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%BE%9B%E5%B7%B4%E5%A8%81" title="辛巴威">辛巴威</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E7%B4%8D%E7%B1%B3%E6%AF%94%E4%BA%9E" title="納米比亞">納米比亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%B3%B4%E7%B4%A2%E6%89%98" title="賴索托">賴索托</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%B3%A2%E6%9C%AD%E9%82%A3" title="波札那">波札那</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8F%B2%E7%93%A6%E6%BF%9F%E8%98%AD" title="史瓦濟蘭">史瓦濟蘭</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8D%97%E9%9D%9E%E5%85%B1%E5%92%8C%E5%9C%8B" title="南非共和國">南非共和國</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%81%96%E8%B5%AB%E5%80%AB%E9%82%A3" title="聖赫倫那">聖赫倫那</a>
                    </td>
                    <td style="text-align: center;">UTC +0:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E6%9F%A5%E5%BE%B7" title="查德">查德</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E4%B8%AD%E9%9D%9E%E5%85%B1%E5%92%8C%E5%9C%8B" title="中非共和國">中非共和國</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%96%80%E9%BA%A5%E9%9A%86" title="喀麥隆">喀麥隆</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E8%B5%A4%E9%81%93%E5%B9%BE%E5%85%A7%E4%BA%9E" title="赤道幾內亞">赤道幾內亞</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%8A%A0%E5%BD%AD" title="加彭">加彭</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%89%9B%E6%9E%9C%E5%85%B1%E5%92%8C%E5%9C%8B" title="剛果共和國">剛果共和國</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td rowspan="2"><a href="/guide/index.php/%E5%89%9B%E6%9E%9C%E6%B0%91%E4%B8%BB%E5%85%B1%E5%92%8C%E5%9C%8B" title="剛果民主共和國">剛果民主共和國</a>
                    </td>
                    <td style="text-align: center;">UTC +1:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>金夏沙、赤道省、下剛果省、班頓杜省
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td>西開賽省、東開賽省、加丹加省、馬尼埃馬省、北基伍省、東方省、南基伍省
                    </td>
                </tr>
                <tr>
                    <td><a href="/guide/index.php/%E5%B0%9A%E6%AF%94%E4%BA%9E" title="尚比亞">尚比亞</a>
                    </td>
                    <td style="text-align: center;">UTC +2:00
                    </td>
                    <td style="text-align: center;">--
                    </td>
                    <td></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
