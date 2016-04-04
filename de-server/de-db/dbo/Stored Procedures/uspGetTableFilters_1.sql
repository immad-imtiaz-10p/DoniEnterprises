
CREATE PROC [dbo].[uspGetTableFilters]
AS
BEGIN	
SELECT BP.Id FROM dbo.BusinessPartner BP WHERE BP.IsBroker = 1
SELECT BP.Id  FROM dbo.BusinessPartner BP WHERE BP.IsShipper = 1
SELECT BP.Id  FROM dbo.BusinessPartner BP WHERE BP.IsSupplier = 1
SELECT BP.Id  FROM dbo.BusinessPartner BP WHERE BP.IsBroker = 1
SELECT P.ProductId AS id,P.ProductName AS text FROM Products P

END