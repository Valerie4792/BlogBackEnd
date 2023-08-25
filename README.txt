//Goal
//Create a back end for a blog site
//create a front end for blog site
//deploy to azure
//learn about DevOps and SCRUM


Create and API for Blog. This API must handle all CRUD
--Create
--Read
--Update
--Delete

//in this app the user should be able to login
//create an account
Blog page to view all the published items
Dashboad(the user profile page for them to edit, delete and add blog items)

We will talk about folder structure
Controller//Folders
    UserController(This will handle all of our user interactions)
    Login//endpoints
    Add a user/endpoints
    Update user
    Delete a user

    -Blog Controller//file
        AddBlogItems//endpoint C
        GetAllBlogItems//endpoint R
        GetBlogItemsByCategory
        GetBlogItemsByTag
        GetBlogItemsByDate
        UpdateBlogItems//endpoint U
        DeleteBlogItems//endpoint D

Model//Folder
    UserModel
        int ID
        string Username
        string Salt
        string Hash 256 characters

    -BlogItemModel
        int ID
        int UserID
        string PublisherName
        string Title
        string Image
        string Description
        string Date
        string Category
        bool IsPublished
        bool IsDeleted

    ----------------------------------Items that will be saved to our DataBase(DB) are above ---------------------------------

        LoginModel
            string Username
            string password
        CreateAccountModel
            int Id =0
            string Username
            string password
        passwordModel
            string Salt
            string Hash
    

    Services//folder
        Context//folder

        UserService//file
            GetUsersByUsername
            Login
            Add User
            Delete User
        BlogItemsService//file
            AddBlogItems//functions C
            GetAllBlogItems//functions R
            GetBlogItemsByCategory
            GetBlogItemsByTag
            GetBlogItemsByDate
            UpdateBlogItems//functions U
            DeleteBlogItems//functions D
            GetuswerByID//functions

    PasswordService//file
        Hash Password
        Verify Hash Password

        



