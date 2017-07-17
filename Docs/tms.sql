
create table SysUser
(
Id int identity(1,1) primary key,
Account nvarchar(50) not null,
Password nvarchar(50) not null,
UserName nvarchar(20),
IsDelete bit not null default 0,--0未删除  1已删除,
SysRoleId int not null,
CreateTime datetime not null default getdate()
)



Create table SysRole
(
Id int identity(1,1) primary key,
Name nvarchar(50),
Number nvarchar(50),
Type int,--0超级管理员 1普通管理员
IsDelete bit not null default 0,
CreateTime datetime not null default getdate() 
)

Create table SysFunc
(
Id int identity(1,1) primary key,
Name nvarchar(50),
OrderNumber int not null,
AreaName nvarchar(50),
ControllerName nvarchar(50),
ActionName nvarchar(50),
ParentFuncId int,
IsDisplay bit not null,
Icon nvarchar(50),
CreateTime datetime not null default getdate()
)

Create table dbo.SysFuncSysRoles
(
SysFuncId int not null,
SysRoleId int not null,
)

USE [TTMS]
GO

ALTER TABLE [dbo].[SysFunc]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SysFunc_dbo.SysFunc_ParentFuncId] FOREIGN KEY([ParentFuncId])
REFERENCES [dbo].[SysFunc] ([Id])
GO

ALTER TABLE [dbo].[SysFunc] CHECK CONSTRAINT [FK_dbo.SysFunc_dbo.SysFunc_ParentFuncId]
GO


USE [TTMS]
GO

ALTER TABLE [dbo].[SysFuncSysRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SysFuncSysRoles_dbo.SysFunc_SysFunc_Id] FOREIGN KEY([SysFuncId])
REFERENCES [dbo].[SysFunc] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SysFuncSysRoles] CHECK CONSTRAINT [FK_dbo.SysFuncSysRoles_dbo.SysFunc_SysFunc_Id]
GO

USE [TTMS]
GO

ALTER TABLE [dbo].[SysFuncSysRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SysFuncSysRoles_dbo.SysRole_SysRole_Id] FOREIGN KEY([SysRoleId])
REFERENCES [dbo].[SysRole] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SysFuncSysRoles] CHECK CONSTRAINT [FK_dbo.SysFuncSysRoles_dbo.SysRole_SysRole_Id]
GO



USE [TTMS]
GO

ALTER TABLE [dbo].[SysUser]  WITH CHECK ADD  CONSTRAINT [FK_SysUser_SysRole1] FOREIGN KEY([SysRoleId])
REFERENCES [dbo].[SysRole] ([Id])
GO

ALTER TABLE [dbo].[SysUser] CHECK CONSTRAINT [FK_SysUser_SysRole1]
GO


create table Banner
(
Id int identity(1,1) primary key,
Title nvarchar(50),
BannerUrl nvarchar(512),
ImgUrl nvarchar(512),
[Description] nvarchar(max),
IsDelete bit not null default 0,
CreateTime datetime not null default getdate()
)





insert into dbo.SysRole(Name, Number, Type, IsDelete, CreateTime) values('超级管理员','',1,0,GETDATE())
insert  into SysUser(Account, Password, UserName, IsDelete, SysRoleId, CreateTime) values('admin','e10adc3949ba59abbe56e057f20f883e','wangjiahao',0,1,GETDATE())

select * from SysFunc
update SysFunc set Name='Banner管理' where id=2
insert into dbo.SysFunc(Name, OrderNumber, IsDisplay, Icon, CreateTime, FuncType)
values('系统管理',1,1,'fa-gear',GETDATE(),1)
insert into dbo.SysFunc(Name, OrderNumber, ControllerName, ActionName, ParentFuncId, IsDisplay, Icon, CreateTime, FuncType)
values('Banner',1,'Banner','BannerMgtResult',1,1,'fa-indent',GETDATE(),2)

insert into dbo.SysFuncSysRoles(SysFuncId, SysRoleId) values(1,1)
insert into dbo.SysFuncSysRoles(SysFuncId, SysRoleId) values(2,1)


