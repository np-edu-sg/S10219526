IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cuisine] (
    [CuisineID] int NOT NULL IDENTITY,
    [CuisineName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cuisine] PRIMARY KEY ([CuisineID])
);
GO

CREATE TABLE [Eatery] (
    [EatyID] int NOT NULL IDENTITY,
    [EatyName] nvarchar(max) NOT NULL,
    [EatyClHr] time NOT NULL,
    [EatyOpHr] time NOT NULL,
    [EatyCapacity] int NOT NULL,
    [EatyLoc] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Eatery] PRIMARY KEY ([EatyID])
);
GO

CREATE TABLE [EventType] (
    [ETID] int NOT NULL IDENTITY,
    [ETName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EventType] PRIMARY KEY ([ETID])
);
GO

CREATE TABLE [FoodCategory] (
    [FcID] int NOT NULL IDENTITY,
    [FcName] nvarchar(max) NOT NULL,
    [FcDescr] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_FoodCategory] PRIMARY KEY ([FcID])
);
GO

CREATE TABLE [Ingredient] (
    [IngredID] int NOT NULL IDENTITY,
    [IngredName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY ([IngredID])
);
GO

CREATE TABLE [Passenger] (
    [PgrID] int NOT NULL IDENTITY,
    [PgrName] nvarchar(max) NOT NULL,
    [PgrEmail] nvarchar(max) NOT NULL,
    [PgrDOB] date NOT NULL,
    [PgrGender] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_Passenger] PRIMARY KEY ([PgrID]),
    CONSTRAINT [CK_Passenger_Gender] CHECK ([PgrGender] IN ('M', 'F'))
);
GO

CREATE TABLE [Dish] (
    [DishID] int NOT NULL IDENTITY,
    [DishName] nvarchar(max) NOT NULL,
    [DishDescr] nvarchar(max) NOT NULL,
    [CuisineID] int NOT NULL,
    [EatyID] int NULL,
    CONSTRAINT [PK_Dish] PRIMARY KEY ([DishID]),
    CONSTRAINT [FK_Dish_Cuisine_CuisineID] FOREIGN KEY ([CuisineID]) REFERENCES [Cuisine] ([CuisineID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Dish_Eatery_EatyID] FOREIGN KEY ([EatyID]) REFERENCES [Eatery] ([EatyID])
);
GO

CREATE TABLE [Event] (
    [EventID] int NOT NULL IDENTITY,
    [EventName] nvarchar(max) NOT NULL,
    [EventDescr] nvarchar(max) NOT NULL,
    [EventLoc] nvarchar(max) NOT NULL,
    [EventCapacity] int NOT NULL,
    [EventDuration] int NOT NULL,
    [MinAge] int NOT NULL,
    [MaxAge] int NOT NULL,
    [AdultPrice] int NOT NULL,
    [ChildPrice] int NOT NULL,
    [EventTypeID] int NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY ([EventID]),
    CONSTRAINT [FK_Event_EventType_EventTypeID] FOREIGN KEY ([EventTypeID]) REFERENCES [EventType] ([ETID]) ON DELETE CASCADE
);
GO

CREATE TABLE [PassengerContactNo] (
    [PassengerID] int NOT NULL,
    [ContactNo] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_PassengerContactNo] PRIMARY KEY ([PassengerID], [ContactNo]),
    CONSTRAINT [FK_PassengerContactNo_Passenger_PassengerID] FOREIGN KEY ([PassengerID]) REFERENCES [Passenger] ([PgrID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reservation] (
    [ReservID] int NOT NULL IDENTITY,
    [ReservStatus] nvarchar(max) NOT NULL,
    [RequiredDateTime] datetime2 NOT NULL,
    [ReservationDateTime] datetime2 NOT NULL,
    [NoOfPax] smallint NOT NULL,
    [EateryID] int NOT NULL,
    [PassengerID] int NOT NULL,
    CONSTRAINT [PK_Reservation] PRIMARY KEY ([ReservID]),
    CONSTRAINT [FK_Reservation_Eatery_EateryID] FOREIGN KEY ([EateryID]) REFERENCES [Eatery] ([EatyID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reservation_Passenger_PassengerID] FOREIGN KEY ([PassengerID]) REFERENCES [Passenger] ([PgrID]) ON DELETE CASCADE
);
GO

CREATE TABLE [CategorisedIn] (
    [DishID] int NOT NULL,
    [FoodCategoryID] int NOT NULL,
    CONSTRAINT [PK_CategorisedIn] PRIMARY KEY ([DishID], [FoodCategoryID]),
    CONSTRAINT [FK_CategorisedIn_Dish_DishID] FOREIGN KEY ([DishID]) REFERENCES [Dish] ([DishID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CategorisedIn_FoodCategory_FoodCategoryID] FOREIGN KEY ([FoodCategoryID]) REFERENCES [FoodCategory] ([FcID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Contains] (
    [DishID] int NOT NULL,
    [IngredientID] int NOT NULL,
    CONSTRAINT [PK_Contains] PRIMARY KEY ([DishID], [IngredientID]),
    CONSTRAINT [FK_Contains_Dish_DishID] FOREIGN KEY ([DishID]) REFERENCES [Dish] ([DishID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Contains_Ingredient_IngredientID] FOREIGN KEY ([IngredientID]) REFERENCES [Ingredient] ([IngredID]) ON DELETE CASCADE
);
GO

CREATE TABLE [CsDish] (
    [DishID] int NOT NULL,
    [Price] float NOT NULL,
    CONSTRAINT [PK_CsDish] PRIMARY KEY ([DishID], [Price]),
    CONSTRAINT [FK_CsDish_Dish_DishID] FOREIGN KEY ([DishID]) REFERENCES [Dish] ([DishID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Order] (
    [OrderDateTime] datetime2 NOT NULL,
    [PgrID] int NOT NULL,
    [DishID] int NOT NULL,
    [OrderQty] int NOT NULL,
    [OrderPrice] float NOT NULL,
    [DeliverTo] nvarchar(max) NOT NULL,
    [DelDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([PgrID], [OrderDateTime], [DishID]),
    CONSTRAINT [FK_Order_Dish_DishID] FOREIGN KEY ([DishID]) REFERENCES [Dish] ([DishID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Order_Passenger_PgrID] FOREIGN KEY ([PgrID]) REFERENCES [Passenger] ([PgrID]) ON DELETE CASCADE
);
GO

CREATE TABLE [EventSession] (
    [SessionNo] int NOT NULL,
    [EventID] int NOT NULL,
    [EventDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_EventSession] PRIMARY KEY ([SessionNo], [EventID]),
    CONSTRAINT [FK_EventSession_Event_EventID] FOREIGN KEY ([EventID]) REFERENCES [Event] ([EventID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Booking] (
    [BookingID] int NOT NULL IDENTITY,
    [NoOfAdultTicket] int NOT NULL,
    [NoOfChildTicket] int NOT NULL,
    [AdultSalesPrice] int NOT NULL,
    [ChildSalesPrice] int NOT NULL,
    [BookDateTime] datetime2 NOT NULL,
    [BookStatus] nvarchar(1) NOT NULL,
    [PassengerID] int NOT NULL,
    [EventSessionEventID] int NOT NULL,
    [EventSessionSessionNo] int NOT NULL,
    CONSTRAINT [PK_Booking] PRIMARY KEY ([BookingID]),
    CONSTRAINT [FK_Booking_EventSession_EventSessionSessionNo_EventSessionEventID] FOREIGN KEY ([EventSessionSessionNo], [EventSessionEventID]) REFERENCES [EventSession] ([SessionNo], [EventID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Booking_Passenger_PassengerID] FOREIGN KEY ([PassengerID]) REFERENCES [Passenger] ([PgrID]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CuisineID', N'CuisineName') AND [object_id] = OBJECT_ID(N'[Cuisine]'))
    SET IDENTITY_INSERT [Cuisine] ON;
INSERT INTO [Cuisine] ([CuisineID], [CuisineName])
VALUES (1, N'Chinese');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CuisineID', N'CuisineName') AND [object_id] = OBJECT_ID(N'[Cuisine]'))
    SET IDENTITY_INSERT [Cuisine] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FcID', N'FcDescr', N'FcName') AND [object_id] = OBJECT_ID(N'[FoodCategory]'))
    SET IDENTITY_INSERT [FoodCategory] ON;
INSERT INTO [FoodCategory] ([FcID], [FcDescr], [FcName])
VALUES (1, N'Halal food for Muslims', N'Halal');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FcID', N'FcDescr', N'FcName') AND [object_id] = OBJECT_ID(N'[FoodCategory]'))
    SET IDENTITY_INSERT [FoodCategory] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IngredID', N'IngredName') AND [object_id] = OBJECT_ID(N'[Ingredient]'))
    SET IDENTITY_INSERT [Ingredient] ON;
INSERT INTO [Ingredient] ([IngredID], [IngredName])
VALUES (1, N'Chicken'),
(2, N'Rice');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IngredID', N'IngredName') AND [object_id] = OBJECT_ID(N'[Ingredient]'))
    SET IDENTITY_INSERT [Ingredient] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PgrID', N'PgrDOB', N'PgrEmail', N'PgrGender', N'PgrName') AND [object_id] = OBJECT_ID(N'[Passenger]'))
    SET IDENTITY_INSERT [Passenger] ON;
INSERT INTO [Passenger] ([PgrID], [PgrDOB], [PgrEmail], [PgrGender], [PgrName])
VALUES (1, '2000-01-01', N'bob@gmail.com', N'M', N'Bob');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PgrID', N'PgrDOB', N'PgrEmail', N'PgrGender', N'PgrName') AND [object_id] = OBJECT_ID(N'[Passenger]'))
    SET IDENTITY_INSERT [Passenger] OFF;
GO

CREATE INDEX [IX_Booking_EventSessionSessionNo_EventSessionEventID] ON [Booking] ([EventSessionSessionNo], [EventSessionEventID]);
GO

CREATE INDEX [IX_Booking_PassengerID] ON [Booking] ([PassengerID]);
GO

CREATE INDEX [IX_CategorisedIn_FoodCategoryID] ON [CategorisedIn] ([FoodCategoryID]);
GO

CREATE INDEX [IX_Contains_IngredientID] ON [Contains] ([IngredientID]);
GO

CREATE UNIQUE INDEX [IX_CsDish_DishID] ON [CsDish] ([DishID]);
GO

CREATE INDEX [IX_Dish_CuisineID] ON [Dish] ([CuisineID]);
GO

CREATE INDEX [IX_Dish_EatyID] ON [Dish] ([EatyID]);
GO

CREATE INDEX [IX_Event_EventTypeID] ON [Event] ([EventTypeID]);
GO

CREATE INDEX [IX_EventSession_EventID] ON [EventSession] ([EventID]);
GO

CREATE INDEX [IX_Order_DishID] ON [Order] ([DishID]);
GO

CREATE UNIQUE INDEX [IX_PassengerContactNo_PassengerID] ON [PassengerContactNo] ([PassengerID]);
GO

CREATE INDEX [IX_Reservation_EateryID] ON [Reservation] ([EateryID]);
GO

CREATE INDEX [IX_Reservation_PassengerID] ON [Reservation] ([PassengerID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220111065005_Initial', N'6.0.1');
GO

COMMIT;
GO

