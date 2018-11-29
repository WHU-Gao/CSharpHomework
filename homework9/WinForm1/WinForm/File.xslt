<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/ArrayOfOrder">
		<html>
			<head>
				<title>Order</title>
			</head>
			<body>
				
				<xsl:for-each select="Order">
				订单ID：
				<xsl:value-of select="ID" />
					<xsl:for-each select="_list">
					<xsl:for-each select="OrderDetails">
						
              商品ID：
							<xsl:value-of select="ID" />
               商品名称：
              <xsl:value-of select="Name" />
			   商品数量：
			  <xsl:value-of select="Count" />
			   商品价格：
			  <xsl:value-of select="Price" />
						<p></p>
					</xsl:for-each>
					</xsl:for-each>
					<xsl:for-each select="Cust">
					 客户名称：
			  <xsl:value-of select="Name" />
			   客户电话：
			  <xsl:value-of select="Number" />
			  <p></p>
					</xsl:for-each>
					</xsl:for-each>
				
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
