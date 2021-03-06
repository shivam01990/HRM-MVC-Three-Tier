USE [HRM]
GO
/****** Object:  Table [dbo].[LeaveType]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveType](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LeaveType] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LeaveType] ON
INSERT [dbo].[LeaveType] ([TypeId], [TypeName]) VALUES (1, N'Sick Leave')
SET IDENTITY_INSERT [dbo].[LeaveType] OFF
/****** Object:  Table [dbo].[LeaveStatusType]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveStatusType](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[LeaveStatus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LeaveStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LeaveStatusType] ON
INSERT [dbo].[LeaveStatusType] ([StatusId], [LeaveStatus]) VALUES (1, N'Pending Approval')
INSERT [dbo].[LeaveStatusType] ([StatusId], [LeaveStatus]) VALUES (2, N'Approved')
INSERT [dbo].[LeaveStatusType] ([StatusId], [LeaveStatus]) VALUES (3, N'Declined')
INSERT [dbo].[LeaveStatusType] ([StatusId], [LeaveStatus]) VALUES (4, N'Cancelled')
SET IDENTITY_INSERT [dbo].[LeaveStatusType] OFF
/****** Object:  Table [dbo].[LeaveDuration]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveDuration](
	[DurationId] [int] IDENTITY(1,1) NOT NULL,
	[DurationType] [nvarchar](max) NOT NULL,
	[NoOfDay] [float] NOT NULL,
 CONSTRAINT [PK_LeaveDuration] PRIMARY KEY CLUSTERED 
(
	[DurationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LeaveDuration] ON
INSERT [dbo].[LeaveDuration] ([DurationId], [DurationType], [NoOfDay]) VALUES (1, N'Full Day', 1)
INSERT [dbo].[LeaveDuration] ([DurationId], [DurationType], [NoOfDay]) VALUES (2, N'Half Day Morning', 0.5)
INSERT [dbo].[LeaveDuration] ([DurationId], [DurationType], [NoOfDay]) VALUES (3, N'Half Day Afternoon', 0.5)
SET IDENTITY_INSERT [dbo].[LeaveDuration] OFF
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'134ce738-3653-4f34-8481-039cbdae518d', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'38edfa6e-3a32-490a-8415-c6a07432c8d9', N'Employee')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd70e5157-4998-4572-b3f5-94b33c78c04a', N'Manager')
/****** Object:  Table [dbo].[Announcement]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[AnnouncementId] [int] NOT NULL,
	[AnnouncementText] [nvarchar](max) NULL,
 CONSTRAINT [PK_Announcement] PRIMARY KEY CLUSTERED 
(
	[AnnouncementId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Announcement] ([AnnouncementId], [AnnouncementText]) VALUES (1, NULL)
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'93d34834-db69-4618-bed1-a9bc10f11992', N'Admin', N'AFpqUs5thO0vQdZR+pWGYcXFE0QYyGp2jFkRfA1+oWtiH5RJNg8PhNh2zYAm5miBKw==', N'd1f4eea6-f518-442b-ba12-2e366b0b848c', N'ApplicationUser')
/****** Object:  Table [dbo].[Users]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PersonalEmail] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[ManagerId] [int] NOT NULL,
	[DesignationId] [int] NULL,
	[ContactNo] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Salary] [money] NULL,
	[Image] [nvarchar](max) NULL,
	[DOB] [datetime] NULL,
	[DOJ] [datetime] NULL,
	[DOR] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserId], [Guid], [Name], [UserName], [Email], [PersonalEmail], [Status], [ManagerId], [DesignationId], [ContactNo], [Address], [Salary], [Image], [DOB], [DOJ], [DOR], [CreatedOn], [UpdatedOn]) VALUES (1, N'93d34834-db69-4618-bed1-a9bc10f11992', N'Admin', N'Admin', N'Admin@admin.com', N'Admin@admin.com', 1, 1, 1, N'9876543210', N'', 0.0000, NULL, NULL, NULL, NULL, CAST(0x0000A47600639453 AS DateTime), CAST(0x0000A47600639453 AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'93d34834-db69-4618-bed1-a9bc10f11992', N'134ce738-3653-4f34-8481-039cbdae518d')
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday](
	[HolidayId] [int] IDENTITY(1,1) NOT NULL,
	[HolidayName] [nvarchar](max) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[LeaveDurationId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED 
(
	[HolidayId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveRequest]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveRequest](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[LeaveStatusId] [int] NOT NULL,
	[LeaveTypeId] [int] NOT NULL,
	[LeaveDurationId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[RequestDate] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_LeaveRequest] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PunchIn] [datetime] NOT NULL,
	[PunchInMessage] [nvarchar](max) NULL,
	[PunchOut] [datetime] NULL,
	[PunchOutMessage] [nvarchar](max) NULL,
	[Duration] [time](7) NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateUser]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shivam Srivastava>
-- Create date: <24-MAR-2015>
-- Description:	<Insert Update User>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertUpdateUser]
    @UserId INT = 0 ,
    @Guid NVARCHAR(128) ,
    @Name NVARCHAR(MAX) ,
    @UserName NVARCHAR(MAX) ,
    @Email NVARCHAR(MAX) ,
    @PersonalEmail NVARCHAR(MAX) ,
    @ManagerId INT ,
    @DesignationId INT ,
    @ContactNo NVARCHAR(MAX) ,
    @Address NVARCHAR(MAX) ,
    @Salary MONEY ,
    @Image NVARCHAR(MAX) ,
    @DOB DATETIME ,
    @DOJ DATETIME ,
    @DOR DATETIME ,
    @Status BIT = 1 ,
    @Output INT = 0 OUT
AS 
    BEGIN	
        SET NOCOUNT ON ;      
        IF NOT EXISTS ( SELECT TOP 1
                                UserId
                        FROM    dbo.Users
                        WHERE   UserID = @UserID ) 
            BEGIN
                INSERT  INTO [dbo].[Users]
                        ( [Guid] ,
                          [Name] ,
                          [UserName] ,
                          [Email] ,
                          [PersonalEmail] ,
                          [ManagerId] ,
                          [DesignationId] ,
                          [ContactNo] ,
                          [Address] ,
                          [Salary] ,
                          [Image] ,
                          [DOB] ,
                          [DOJ] ,
                          [Status] ,
                          [CreatedOn] ,
                          [UpdatedOn]
                        )
                VALUES  ( @Guid ,
                          @Name ,
                          @UserName ,
                          @Email ,
                          @PersonalEmail ,
                          @ManagerId ,
                          @DesignationId ,
                          @ContactNo ,
                          @Address ,
                          @Salary ,
                          @Image ,
                          @DOB ,
                          @DOJ ,
                          @Status ,
                          GETUTCDATE() ,
                          GETUTCDATE()
                        )
                SET @Output = SCOPE_IDENTITY()  
            END
        ELSE 
            BEGIN 
                UPDATE  [dbo].[Users]
                SET     [Name] = @Name ,
                        [Email] = @Email ,
                        [PersonalEmail] = @PersonalEmail ,
                        [Address] = @Address ,
                        [ContactNo] = @ContactNo ,
                        [ManagerId] = @ManagerId ,
                        [DesignationId] = @DesignationId ,
                        [Salary] = @Salary ,
                        [Image] = @Image ,
                        [DOB] = @DOB ,
                        [DOJ] = @DOJ ,
                        [DOR] = @DOR ,
                        [Status] = @Status ,
                        [UpdatedOn] = GETUTCDATE()
                WHERE   UserId = @UserId
                SET @Output = @userId
            END
  
    END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHoliday]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shivam Srivastva>
-- Create date: <9-April-2015>
-- Description:	<Get Users Holidays>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetHoliday]
	-- Add the parameters for the stored procedure here
    @HolidayId INT = 0 ,
    @HolidayName NVARCHAR(MAX) = '' ,
    @StartDate DATETIME = NULL ,
    @EndDate DATETIME = NULL ,
    @LeaveDurationId INT = 0
AS 
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON ;

    -- Insert statements for procedure here
        SELECT  h.[HolidayId] ,
                h.[HolidayName] ,
                h.[StartDate] ,
                h.[EndDate] ,
                ( CASE WHEN DATEDIFF(dd, h.[StartDate], h.[EndDate]) = 0
                       THEN 1
                       ELSE DATEDIFF(dd, h.[StartDate], h.[EndDate]) + 1
                  END ) * d.NoOfDay AS TotalDays ,
                h.[LeaveDurationId] ,
                d.DurationType ,
                h.[CreatedBy] ,
                h.[UpdatedBy] ,
                h.[CreatedOn] ,
                h.[UpdatedOn]
        FROM    [dbo].[Holiday] h
                INNER JOIN dbo.LeaveDuration d ON h.LeaveDurationId = d.DurationId
        WHERE   @HolidayId IN ( 0, h.HolidayId )
                AND @HolidayName IN ( '', h.HolidayName )
                AND @LeaveDurationId IN ( 0, d.DurationId )
                AND ( ( @StartDate IS NULL )
                      OR ( @StartDate < h.StartDate )
                    )
                AND ( ( @EndDate IS NULL )
                      OR ( @EndDate > h.EndDate )
                    )
        ORDER BY h.StartDate ASC   
                 
    END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUser]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shivam Srivastava>
-- Create date: <2-April-2015>
-- Description:	<Get User>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUser] 
	-- Add the parameters for the stored procedure here
    @UserId INT = 0 ,
    @ManagerId INT = 0 ,
    @Name NVARCHAR(MAX) = '' ,
    @UserName NVARCHAR(MAX) = '' ,
    @Email NVARCHAR(MAX) = '' ,
    @RoleName NVARCHAR(MAX) = ''
AS 
    BEGIN
	
        SET NOCOUNT ON ; 
        SELECT DISTINCT
                u.UserId ,
                u.Name ,
                u.UserName ,
                u.Guid ,
                ar.Name AS RoleName ,
                u.ManagerId ,
                u.DesignationId ,
                d.DesignationName ,
                m.Name AS ManagerName ,
                u.Email ,
                u.PersonalEmail ,
                u.ContactNo ,
                u.Address ,
                u.Salary ,
                u.Image ,
                u.DOB ,
                u.DOJ ,
                u.DOR ,
                u.Status ,
                u.CreatedOn ,
                u.UpdatedOn
        FROM    dbo.AspNetUsers au
                INNER JOIN dbo.AspNetUserRoles aur ON au.Id = aur.UserId
                INNER JOIN dbo.AspNetRoles ar ON aur.RoleId = ar.Id
                INNER JOIN dbo.Users u ON au.Id = u.Guid
                INNER JOIN dbo.Users m ON u.ManagerId = m.UserId
                LEFT JOIN dbo.Designation d ON u.DesignationId = d.DesignationId
        WHERE   @UserId IN ( u.UserId, 0 )
                AND @Name IN ( '', u.Name )
                AND @UserName IN ( '', u.UserName )
                AND @Email IN ( '', u.Email )
                AND @RoleName IN ( '', ar.Name )
                AND @ManagerId IN ( 0, u.ManagerId )
        ORDER BY u.CreatedOn DESC
    END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateHolidays]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shivam Srivastava>
-- Create date: <8-April-2015>
-- Description:	<Insert Update Holidays>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertUpdateHolidays]
    @HolidayId INT ,
    @HolidayName VARCHAR(MAX) ,
    @StartDate DATETIME ,
    @EndDate DATETIME ,
    @LeaveDurationId INT ,
    @CreatedBy INT ,
    @UpdatedBy INT ,
    @Output INT = 0 OUT
AS 
    BEGIN
        SET NOCOUNT ON ;
        IF NOT EXISTS ( SELECT TOP 1
                                HolidayId
                        FROM    dbo.Holiday
                        WHERE   HolidayId = @HolidayId ) 
            BEGIN
                DECLARE @Count INT= 0
            
                SELECT  @Count = COUNT(*)
                FROM    dbo.Holiday
                WHERE   ( StartDate >= @StartDate
                          AND StartDate <= @EndDate
                        )
                        OR ( EndDate >= @StartDate
                             AND EndDate <= @EndDate
                           )
                SET @Output = 0 
                IF @Count = 0 
                    BEGIN         
                       
                        INSERT  INTO [dbo].[Holiday]
                                ( [HolidayName] ,
                                  [StartDate] ,
                                  [EndDate] ,
                                  [LeaveDurationId] ,
                                  [CreatedBy] ,
                                  [UpdatedBy] ,
                                  [CreatedOn] ,
                                  [UpdatedOn]
                                )
                        VALUES  ( @HolidayName ,
                                  @StartDate ,
                                  @EndDate ,
                                  @LeaveDurationId ,
                                  @CreatedBy ,
                                  @UpdatedBy ,
                                  GETUTCDATE() ,
                                  GETUTCDATE()
                                )
                        SET @Output = SCOPE_IDENTITY()    
                    END     
            END
        ELSE 
            BEGIN
                UPDATE  [dbo].[Holiday]
                SET     [HolidayName] = @HolidayName ,
                        [StartDate] = @StartDate ,
                        [EndDate] = @EndDate ,
                        [LeaveDurationId] = @LeaveDurationId ,
                        [UpdatedBy] = @UpdatedBy ,
                        [UpdatedOn] = GETUTCDATE()
                WHERE   HolidayId = @HolidayId
                SET @Output = @HolidayId
            END
  
    END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateAttendance]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shivam Srivastava>
-- Create date: <27-MAR-2015>
-- Description:	<Insert Update Attendance>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertUpdateAttendance]
    @AttendanceId INT = 0 ,
    @UserId INT ,
    @PunchInMessage NVARCHAR(MAX) ,
    @PunchOutMessage NVARCHAR(MAX) ,
    @Output INT = 0 OUT
AS 
    BEGIN	
        SET NOCOUNT ON ;
	
        IF NOT EXISTS ( SELECT TOP 1
                                AttendanceId
                        FROM    dbo.Attendance
                        WHERE   AttendanceId = @AttendanceId ) 
            BEGIN
            
                INSERT  INTO dbo.Attendance
                        ( UserId ,
                          PunchIn ,
                          PunchInMessage  
                        )
                VALUES  ( @UserId , -- UserId - int
                          GETUTCDATE() , -- PunchIn - datetime
                          @PunchInMessage -- PunchInMessage - nvarchar(max)                    
                        )
                SET @Output = SCOPE_IDENTITY()  
            END
        ELSE 
            BEGIN
                UPDATE  dbo.Attendance
                SET     PunchOut = GETUTCDATE() ,
                        PunchOutMessage = @PunchOutMessage ,
                        Duration = ( GETUTCDATE() - PunchIn )
                WHERE   AttendanceId = @AttendanceId
                SET @Output = @AttendanceId
            END
   
    END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLeaveRequest]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shivam Srivastava>
-- Create date: <31-Feb-2015>
-- Description:	<Get Leaves>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetLeaveRequest]
	-- Add the parameters for the stored procedure here
    @RequestId INT = 0 ,
    @UserId INT = 0 ,
    @ManagerId INT = 0 ,
    @LeaveStatusId INT = 0 ,
    @StartDate DATETIME ,
    @EndDate DATETIME ,
    @UpdatedBy INT
AS 
    BEGIN	
        SET NOCOUNT ON ;
 
        SELECT  l.[RequestId] ,
                l.[UserId] ,
                u1.Name AS Name ,
                l.[LeaveStatusId] ,
                ls.LeaveStatus ,
                l.[LeaveTypeId] ,
                lt.TypeName ,
                l.LeaveDurationId ,
                d.DurationType ,
                l.[StartTime] ,
                l.[EndTime] ,
                ( CASE WHEN DATEDIFF(dd, l.[StartTime], l.[EndTime]) = 0
                       THEN 1
                       ELSE DATEDIFF(dd, l.[StartTime], l.[EndTime]) + 1
                  END ) * d.NoOfDay AS TotalDays ,
                l.[Description] ,
                l.[RequestDate] ,
                l.[UpdatedOn] ,
                l.[UpdatedBy] ,
                u2.Name AS UpdatedByName
        FROM    [dbo].[LeaveRequest] l
                INNER JOIN dbo.LeaveStatusType ls ON l.LeaveStatusId = ls.StatusId
                INNER JOIN dbo.LeaveType lt ON l.LeaveTypeId = lt.TypeId
                INNER JOIN dbo.Users u1 ON l.UserId = u1.UserId
                INNER JOIN dbo.Users u2 ON l.UpdatedBy = u2.UserId
                INNER JOIN dbo.LeaveDuration d ON d.DurationId = l.LeaveDurationId
        WHERE   @RequestId IN ( 0, l.RequestId )
                AND @UserId IN ( 0, u1.UserId )
                AND @UpdatedBy IN ( 0, u2.UserId )
                AND ( ( l.RequestDate >= @StartDate )
                      OR ( @StartDate IS NULL )
                    )
                AND ( ( l.RequestDate <= @EndDate )
                      OR ( @EndDate IS NULL )
                    )
                AND @LeaveStatusId IN ( 0, l.LeaveStatusId )
                AND @ManagerId IN ( 0, u1.ManagerId )
                AND u1.Status=1
        ORDER BY ( CASE WHEN ls.StatusId = 1 THEN 0
                        ELSE 1
                   END ) ,
                l.RequestDate DESC
                    
 
    END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAttendance]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shivam Srivastava>
-- Create date: <Get Attendance>
-- Description:	<Get All Attendance>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAttendance]
    @AttendanceId INT = 0 ,
    @UserId INT = 0 ,
    @ManagerId INT =0,
    @StartDate DATETIME = NULL ,
    @EndDate DATETIME = NULL
AS 
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON ;

        SELECT  a.[AttendanceId] ,
                a.[UserId] ,
                u.[UserName] ,
                a.[PunchIn] ,
                a.[PunchInMessage] ,
                a.[PunchOut] ,
                a.[PunchOutMessage] ,
                a.[Duration]
        FROM    [dbo].[Attendance] a
                INNER JOIN dbo.Users u ON a.UserId = u.UserId
        WHERE   @UserId IN ( 0, u.UserId )
                AND @AttendanceId IN ( 0, a.AttendanceId )
                AND ( ( a.PunchIn > @StartDate )
                      OR ( @StartDate IS NULL )
                    )
                AND ( ( a.PunchIn < @EndDate )
                      OR ( @EndDate IS NULL )
                    )
                AND @ManagerId IN (u.ManagerId,0)    
        ORDER BY PunchIn DESC
    END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateLeaveRequest]    Script Date: 04/10/2015 11:41:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shivam Srivastava>
-- Create date: <31-March-2015>
-- Description:	<Leave Request>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertUpdateLeaveRequest]
    @RequestId INT ,
    @UserId INT ,
    @LeaveStatusId INT ,
    @LeaveTypeId INT ,
    @LeaveDurationId INT ,
    @StartTime DATETIME ,
    @EndTime DATETIME ,
    @Description NVARCHAR(MAX) ,
    @UpdatedBy INT ,
    @Output INT = 0 OUT
AS 
    BEGIN
        SET NOCOUNT ON ;

        IF NOT EXISTS ( SELECT TOP 1
                                RequestId
                        FROM    dbo.LeaveRequest
                        WHERE   RequestId = @RequestId ) 
            BEGIN
                DECLARE @Count INT= 0
            
                SELECT  @Count = COUNT(*)
                FROM    dbo.LeaveRequest
                WHERE   ( StartTime >= @StartTime
                          AND StartTime <= @EndTime
                          AND UserId = @UserId
                        )
                        OR ( EndTime >= @StartTime
                             AND EndTime <= @EndTime
                             AND UserId = @UserId
                           )
                        AND UserId = @UserId
                SET @Output = 0 
                IF @Count = 0 
                    BEGIN
                        INSERT  INTO [dbo].[LeaveRequest]
                                ( [UserId] ,
                                  [LeaveStatusId] ,
                                  [LeaveTypeId] ,
                                  [LeaveDurationId] ,
                                  [StartTime] ,
                                  [EndTime] ,
                                  [Description] ,
                                  [RequestDate] ,
                                  [UpdatedBy] ,
                                  [UpdatedOn]
                                )
                        VALUES  ( @UserId ,
                                  @LeaveStatusId ,
                                  @LeaveTypeId ,
                                  @LeaveDurationId ,
                                  @StartTime ,
                                  @EndTime ,
                                  @Description ,
                                  GETUTCDATE() ,
                                  @UpdatedBy ,
                                  GETUTCDATE()
                                )
                        SET @Output = SCOPE_IDENTITY()  
                    END                
               
            END
        ELSE 
            BEGIN
                UPDATE  dbo.LeaveRequest
                SET     UpdatedOn = GETUTCDATE() ,
                        LeaveStatusId = @LeaveStatusId ,
                        UpdatedBy = @UpdatedBy
                WHERE   RequestId = @RequestId
                SET @Output = @RequestId
            END
    END
GO
/****** Object:  Default [DF_Attendance_PunchIn]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_PunchIn]  DEFAULT (getutcdate()) FOR [PunchIn]
GO
/****** Object:  Default [DF_Holiday_CreatedOn]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Holiday] ADD  CONSTRAINT [DF_Holiday_CreatedOn]  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_Holiday_UpdatedOn]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Holiday] ADD  CONSTRAINT [DF_Holiday_UpdatedOn]  DEFAULT (getutcdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_LeaveRequest_RequestDate]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[LeaveRequest] ADD  CONSTRAINT [DF_LeaveRequest_RequestDate]  DEFAULT (getutcdate()) FOR [RequestDate]
GO
/****** Object:  Default [DF_Users_Status]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_Users_DOJ]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_DOJ]  DEFAULT (getutcdate()) FOR [DOJ]
GO
/****** Object:  Default [DF_Users_CreatedOn]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedOn]  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_Users_UpdatedOn]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UpdatedOn]  DEFAULT (getutcdate()) FOR [UpdatedOn]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_Attendance_Users]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Attendance]  WITH NOCHECK ADD  CONSTRAINT [FK_Attendance_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Attendance] NOCHECK CONSTRAINT [FK_Attendance_Users]
GO
/****** Object:  ForeignKey [FK_Holiday_LeaveDuration]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Holiday]  WITH NOCHECK ADD  CONSTRAINT [FK_Holiday_LeaveDuration] FOREIGN KEY([LeaveDurationId])
REFERENCES [dbo].[LeaveDuration] ([DurationId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Holiday] NOCHECK CONSTRAINT [FK_Holiday_LeaveDuration]
GO
/****** Object:  ForeignKey [FK_LeaveRequest_LeaveDuration]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[LeaveRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_LeaveRequest_LeaveDuration] FOREIGN KEY([LeaveDurationId])
REFERENCES [dbo].[LeaveDuration] ([DurationId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[LeaveRequest] NOCHECK CONSTRAINT [FK_LeaveRequest_LeaveDuration]
GO
/****** Object:  ForeignKey [FK_LeaveRequest_LeaveStatusType]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[LeaveRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_LeaveRequest_LeaveStatusType] FOREIGN KEY([LeaveStatusId])
REFERENCES [dbo].[LeaveStatusType] ([StatusId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[LeaveRequest] NOCHECK CONSTRAINT [FK_LeaveRequest_LeaveStatusType]
GO
/****** Object:  ForeignKey [FK_LeaveRequest_LeaveType]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[LeaveRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_LeaveRequest_LeaveType] FOREIGN KEY([LeaveTypeId])
REFERENCES [dbo].[LeaveType] ([TypeId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[LeaveRequest] NOCHECK CONSTRAINT [FK_LeaveRequest_LeaveType]
GO
/****** Object:  ForeignKey [FK_LeaveRequest_Users]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[LeaveRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_LeaveRequest_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[LeaveRequest] NOCHECK CONSTRAINT [FK_LeaveRequest_Users]
GO
/****** Object:  ForeignKey [FK_Users_AspNetUsers]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Users]  WITH NOCHECK ADD  CONSTRAINT [FK_Users_AspNetUsers] FOREIGN KEY([Guid])
REFERENCES [dbo].[AspNetUsers] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Users] NOCHECK CONSTRAINT [FK_Users_AspNetUsers]
GO
/****** Object:  ForeignKey [FK_Users_Designation]    Script Date: 04/10/2015 11:41:19 ******/
ALTER TABLE [dbo].[Users]  WITH NOCHECK ADD  CONSTRAINT [FK_Users_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([DesignationId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Users] NOCHECK CONSTRAINT [FK_Users_Designation]
GO
