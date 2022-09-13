Create Database BloggerWebsite
Go

Use BloggerWebsite
Go

Create Table Post (
	PostID int primary key,
	Title nvarchar(50) Not Null,
	Content nvarchar(500) Not Null,
	CreateAt Datetime Default(GetDate()) Not Null,
	PostStatus bit Default(1),
	Images nvarchar(50),
	UserID int,
	CategoryID int

	Foreign Key (UserID) references [User],
	Foreign Key (CategoryID) references Category
)
Go

Create Table Category (
	CategoryID int primary key,
	CategoryName nvarchar(20) Not Null
)
Go

Create Table [User] (
	UserID int primary key,
	UserName nvarchar(50) Not Null,
	FirstName nvarchar(50) Not Null,
	LastName nvarchar(50) Not Null,
	Email nvarchar(50) Not Null,
	[Password] nvarchar (20) Not Null
)
Go

Create Table Review (
	CommentID int primary key,
	Content nvarchar(100),
	CreateAt nvarchar(20),
	UserID int,
	PostID int,

	Foreign Key (PostID) references Post,
	Foreign Key (UserID) references [User]
)
Go

Create Table SubReview (
	SubCommentID int primary key,
	CommentID int

	Foreign Key (CommentID) references Review
)
Go

Drop Database BloggerWebsite
Go