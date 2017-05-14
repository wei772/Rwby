use Global

DECLARE @ClientId nvarchar(50)='mvc'

SELECT c.ClientId,
        c.ClientName,
        c.AllowAccessTokensViaBrowser
FROM Clients AS c
WHERE ClientId=@ClientId

SELECT c.ClientId,
        c.ClientName,
        cu.RedirectUri
FROM Clients AS c left outer
        JOIN ClientRedirectUris AS cu
        ON c.Id=cu.ClientId
WHERE c.ClientId=@ClientId

SELECT c.ClientId,
        c.ClientName,
        cp.PostLogoutRedirectUri
FROM Clients AS c left outer
        JOIN ClientPostLogoutRedirectUris AS cp
        ON c.Id=cp.ClientId
WHERE c.ClientId=@ClientId

SELECT c.ClientId,
        c.ClientName,
        cs.Scope
FROM Clients AS c left outer
        JOIN ClientScopes AS cs
        ON c.Id=cs.ClientId
WHERE c.ClientId=@ClientId

SELECT c.ClientId,
        c.ClientName,
        cc.Origin
FROM Clients AS c left outer
        JOIN ClientCorsOrigins AS cc
        ON c.Id=cc.ClientId
WHERE c.ClientId=@ClientId

SELECT c.ClientId,
        c.ClientName,
        cg.GrantType
FROM Clients AS c left outer
        JOIN ClientGrantTypes AS cg
        ON c.Id=cg.ClientId
WHERE c.ClientId=@ClientId 