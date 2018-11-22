<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<HTML>
    <head>
        <title>Order</title>
    </head>
<body>
    <table>
        <xsl:apply-templates/>
    </table>          
</body>  
</HTML>
</xsl:template>

<xsl:template match="ArrayOfOrder">
    <xsl:apply-templates select="Order"/>
</xsl:template>

<xsl:template match="Order">
<tr>
     <td>
        <xsl:value-of select="orderDetails/Customer/Name"/>
     </td>
<td>
        <xsl:value-of select="orderDetails/Customer/Telephone"/>
     </td>
     <td>
        <xsl:value-of select="orderDetails/goodslist/Goods/Name"/>
     </td>
     <td>
         <xsl:value-of select="orderDetails/goodslist/Goods/Count"/>
       </td>
</tr>


</xsl:template>
    


</xsl:stylesheet>