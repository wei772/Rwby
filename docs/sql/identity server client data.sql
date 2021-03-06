USE [Global]
GO
SET IDENTITY_INSERT [dbo].[ApiResources] ON 

INSERT [dbo].[ApiResources] ([Id], [Description], [DisplayName], [Enabled], [Name]) VALUES (1, NULL, N'User API', 1, N'UserApi')
SET IDENTITY_INSERT [dbo].[ApiResources] OFF
SET IDENTITY_INSERT [dbo].[ApiScopes] ON 

INSERT [dbo].[ApiScopes] ([Id], [ApiResourceId], [Description], [DisplayName], [Emphasize], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (1, 1, NULL, N'User Api', 0, N'UserApi', 0, 1)
SET IDENTITY_INSERT [dbo].[ApiScopes] OFF
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [AbsoluteRefreshTokenLifetime], [AccessTokenLifetime], [AccessTokenType], [AllowAccessTokensViaBrowser], [AllowOfflineAccess], [AllowPlainTextPkce], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [AlwaysSendClientClaims], [AuthorizationCodeLifetime], [ClientId], [ClientName], [ClientUri], [EnableLocalLogin], [Enabled], [IdentityTokenLifetime], [IncludeJwtId], [LogoUri], [LogoutSessionRequired], [LogoutUri], [PrefixClientClaims], [ProtocolType], [RefreshTokenExpiration], [RefreshTokenUsage], [RequireClientSecret], [RequireConsent], [RequirePkce], [SlidingRefreshTokenLifetime], [UpdateAccessTokenClaimsOnRefresh]) VALUES (1, 2592000, 3600, 0, 0, 0, 0, 1, 0, 0, 300, N'client', N'Client', NULL, 1, 1, 300, 0, NULL, 1, NULL, 1, N'oidc', 1, 1, 1, 1, 0, 1296000, 0)
INSERT [dbo].[Clients] ([Id], [AbsoluteRefreshTokenLifetime], [AccessTokenLifetime], [AccessTokenType], [AllowAccessTokensViaBrowser], [AllowOfflineAccess], [AllowPlainTextPkce], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [AlwaysSendClientClaims], [AuthorizationCodeLifetime], [ClientId], [ClientName], [ClientUri], [EnableLocalLogin], [Enabled], [IdentityTokenLifetime], [IncludeJwtId], [LogoUri], [LogoutSessionRequired], [LogoutUri], [PrefixClientClaims], [ProtocolType], [RefreshTokenExpiration], [RefreshTokenUsage], [RequireClientSecret], [RequireConsent], [RequirePkce], [SlidingRefreshTokenLifetime], [UpdateAccessTokenClaimsOnRefresh]) VALUES (2, 2592000, 3600, 0, 0, 0, 0, 1, 0, 0, 300, N'ro.client', N'Resource Owner Client', NULL, 1, 1, 300, 0, NULL, 1, NULL, 1, N'oidc', 1, 1, 1, 1, 0, 1296000, 0)
INSERT [dbo].[Clients] ([Id], [AbsoluteRefreshTokenLifetime], [AccessTokenLifetime], [AccessTokenType], [AllowAccessTokensViaBrowser], [AllowOfflineAccess], [AllowPlainTextPkce], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [AlwaysSendClientClaims], [AuthorizationCodeLifetime], [ClientId], [ClientName], [ClientUri], [EnableLocalLogin], [Enabled], [IdentityTokenLifetime], [IncludeJwtId], [LogoUri], [LogoutSessionRequired], [LogoutUri], [PrefixClientClaims], [ProtocolType], [RefreshTokenExpiration], [RefreshTokenUsage], [RequireClientSecret], [RequireConsent], [RequirePkce], [SlidingRefreshTokenLifetime], [UpdateAccessTokenClaimsOnRefresh]) VALUES (3, 2592000, 3600, 0, 0, 1, 0, 1, 0, 0, 300, N'mvc', N'MVC Client', NULL, 1, 1, 300, 0, NULL, 1, NULL, 1, N'oidc', 1, 1, 1, 1, 0, 1296000, 0)
INSERT [dbo].[Clients] ([Id], [AbsoluteRefreshTokenLifetime], [AccessTokenLifetime], [AccessTokenType], [AllowAccessTokensViaBrowser], [AllowOfflineAccess], [AllowPlainTextPkce], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [AlwaysSendClientClaims], [AuthorizationCodeLifetime], [ClientId], [ClientName], [ClientUri], [EnableLocalLogin], [Enabled], [IdentityTokenLifetime], [IncludeJwtId], [LogoUri], [LogoutSessionRequired], [LogoutUri], [PrefixClientClaims], [ProtocolType], [RefreshTokenExpiration], [RefreshTokenUsage], [RequireClientSecret], [RequireConsent], [RequirePkce], [SlidingRefreshTokenLifetime], [UpdateAccessTokenClaimsOnRefresh]) VALUES (4, 2592000, 3600, 0, 1, 0, 0, 1, 0, 0, 300, N'js', N'JavaScript Client', NULL, 1, 1, 300, 0, NULL, 1, NULL, 1, N'oidc', 1, 1, 0, 1, 0, 1296000, 0)
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[ClientCorsOrigins] ON 

INSERT [dbo].[ClientCorsOrigins] ([Id], [ClientId], [Origin]) VALUES (1, 4, N'http://localhost:50115')
SET IDENTITY_INSERT [dbo].[ClientCorsOrigins] OFF
SET IDENTITY_INSERT [dbo].[ClientGrantTypes] ON 

INSERT [dbo].[ClientGrantTypes] ([Id], [ClientId], [GrantType]) VALUES (1, 1, N'client_credentials')
INSERT [dbo].[ClientGrantTypes] ([Id], [ClientId], [GrantType]) VALUES (2, 4, N'implicit')
INSERT [dbo].[ClientGrantTypes] ([Id], [ClientId], [GrantType]) VALUES (3, 2, N'password')
INSERT [dbo].[ClientGrantTypes] ([Id], [ClientId], [GrantType]) VALUES (4, 3, N'hybrid')
INSERT [dbo].[ClientGrantTypes] ([Id], [ClientId], [GrantType]) VALUES (5, 3, N'client_credentials')
SET IDENTITY_INSERT [dbo].[ClientGrantTypes] OFF
SET IDENTITY_INSERT [dbo].[ClientPostLogoutRedirectUris] ON 

INSERT [dbo].[ClientPostLogoutRedirectUris] ([Id], [ClientId], [PostLogoutRedirectUri]) VALUES (1, 3, N'http://localhost:50111/signout-callback-oidc')
INSERT [dbo].[ClientPostLogoutRedirectUris] ([Id], [ClientId], [PostLogoutRedirectUri]) VALUES (2, 4, N'http://localhost:50115/index.html')
SET IDENTITY_INSERT [dbo].[ClientPostLogoutRedirectUris] OFF
SET IDENTITY_INSERT [dbo].[ClientRedirectUris] ON 

INSERT [dbo].[ClientRedirectUris] ([Id], [ClientId], [RedirectUri]) VALUES (1, 3, N'http://localhost:50111/signin-oidc')
INSERT [dbo].[ClientRedirectUris] ([Id], [ClientId], [RedirectUri]) VALUES (2, 4, N'http://localhost:50115/callback.html')
SET IDENTITY_INSERT [dbo].[ClientRedirectUris] OFF
SET IDENTITY_INSERT [dbo].[ClientScopes] ON 

INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (1, 3, N'openid')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (2, 2, N'UserApi')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (3, 1, N'UserApi')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (4, 4, N'openid')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (5, 4, N'profile')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (6, 4, N'UserApi')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (7, 3, N'profile')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (8, 3, N'UserApi')
SET IDENTITY_INSERT [dbo].[ClientScopes] OFF
SET IDENTITY_INSERT [dbo].[ClientSecrets] ON 

INSERT [dbo].[ClientSecrets] ([Id], [ClientId], [Description], [Expiration], [Type], [Value]) VALUES (1, 3, NULL, NULL, N'SharedSecret', N'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=')
INSERT [dbo].[ClientSecrets] ([Id], [ClientId], [Description], [Expiration], [Type], [Value]) VALUES (2, 2, NULL, NULL, N'SharedSecret', N'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=')
INSERT [dbo].[ClientSecrets] ([Id], [ClientId], [Description], [Expiration], [Type], [Value]) VALUES (3, 1, NULL, NULL, N'SharedSecret', N'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=')
SET IDENTITY_INSERT [dbo].[ClientSecrets] OFF
SET IDENTITY_INSERT [dbo].[IdentityResources] ON 

INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (1, NULL, N'Your user identifier', 0, 1, N'openid', 1, 1)
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (2, N'Your user profile information (first name, last name, etc.)', N'User profile', 1, 1, N'profile', 0, 1)
SET IDENTITY_INSERT [dbo].[IdentityResources] OFF
SET IDENTITY_INSERT [dbo].[IdentityClaims] ON 

INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (1, 1, N'sub')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (2, 2, N'name')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (3, 2, N'family_name')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (4, 2, N'given_name')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (5, 2, N'middle_name')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (6, 2, N'nickname')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (7, 2, N'preferred_username')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (8, 2, N'profile')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (9, 2, N'picture')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (10, 2, N'website')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (11, 2, N'gender')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (12, 2, N'birthdate')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (13, 2, N'zoneinfo')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (14, 2, N'locale')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (15, 2, N'updated_at')
SET IDENTITY_INSERT [dbo].[IdentityClaims] OFF
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'IOJCPwEQ2Etyn+QoaAdj9RXXB7eE3Wb55U3KL+CAzQ8=', N'mvc', CAST(N'2017-05-14T09:30:09.9605866' AS DateTime2), N'{"SubjectId":"eb9316d9-4e5c-45fb-af41-50c193140012","ClientId":"mvc","Scopes":["openid","profile","UserApi","offline_access"],"CreationTime":"2017-05-14T09:30:09.9605866Z","Expiration":null}', NULL, N'eb9316d9-4e5c-45fb-af41-50c193140012', N'user_consent')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'KnbEq/mMN4e7VUU3axu5b9KIyvRUTz6pBbZ78HJ8ttI=', N'mvc', CAST(N'2017-05-14T09:30:12.6887689' AS DateTime2), N'{"CreationTime":"2017-05-14T09:30:12.6887689Z","Lifetime":2592000,"AccessToken":{"Audiences":["http://localhost:50274/resources","UserApi"],"Issuer":"http://localhost:50274","CreationTime":"2017-05-14T09:30:12.6372909Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"UserApi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"eb9316d9-4e5c-45fb-af41-50c193140012","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1494754203","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2017-06-13T09:30:12.6887689' AS DateTime2), N'eb9316d9-4e5c-45fb-af41-50c193140012', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'Y//EV7+JxSnmkKpgqcQ5jvLOcPcPdTv+vumQWKsOzag=', N'js', CAST(N'2017-05-14T09:24:34.9218875' AS DateTime2), N'{"SubjectId":"eb9316d9-4e5c-45fb-af41-50c193140012","ClientId":"js","Scopes":["openid","profile","UserApi"],"CreationTime":"2017-05-14T09:24:34.9218875Z","Expiration":null}', NULL, N'eb9316d9-4e5c-45fb-af41-50c193140012', N'user_consent')
