Restaurant Management API
Overview

This API provides functionalities for managing bookings, customers, menus, and restaurants. It allows users to create, update, retrieve, and delete records related to these entities within a restaurant management system.

Endpoints:

Booking Management

    POST /booktable
    Books a table at a restaurant. You need to provide the customer ID, restaurant ID, booking start and end times, and number of guests.

    DELETE /deletebooking/{reservationId}
    Deletes a booking using its reservation ID.

    PUT /updatebooking/{reservationId}
    Updates an existing booking. The reservation ID and updated booking details must be provided.

    POST /addtable
    Adds a new table to a restaurant. Include details like table number, number of seats, restaurant ID, and availability.

    PUT /updatetable/{tableId}
    Updates details of an existing table using its ID.

    DELETE /deletetable/{tableId}
    Deletes a table based on its ID.

Customer Management

    POST /addcustomer
    Adds a new customer. Provide the customer’s name, phone number, and email address.

    DELETE /deletecustomer
    Deletes a customer using their customer ID.

    GET /{customerId}
    Retrieves information about a specific customer using their ID.

    GET /viewcustomers
    Retrieves a list of all customers associated with a specific restaurant. Provide the restaurant name.

    PUT /updatecustomer/{customerId}
    Updates a customer’s details using their ID.

Menu and Orders

    POST /addmenuitem
    Adds a new menu item to a restaurant's menu. Provide the item’s name, type (dish or drink), price, availability, and restaurant ID.

    DELETE /deletedish/{menuId}
    Deletes a menu item using its ID.

    PUT /updatemenuitem/{menuId}
    Updates a menu item’s details using its ID.

    GET /viewdish/{menuId}
    Retrieves details of a specific menu item using its ID.

    GET /viewmenu/{restaurantId}
    Retrieves the menu for a specific restaurant using its ID.

    POST /addorder
    Places a new order for a table. Include details such as amount, customer ID, menu item ID, and table ID.

    DELETE /deleteorder/{orderId}
    Deletes an order using its ID.

    PUT /updateorder/{orderId}
    Updates an order's details using its ID.

    GET /getorder/{orderId}
    Retrieves details of a specific order using its ID.

    GET /vieworders/{tableId}
    Retrieves all orders associated with a specific table using its ID.

Restaurant Management

    POST /addrestaurant
    Adds a new restaurant. Provide the restaurant’s name and location.

    PUT /updaterestaurant/{restaurantId}
    Updates details of a restaurant using its ID.

    DELETE /deleterestaurant/{restaurantId}
    Deletes a restaurant using its ID.

    GET /viewrestaurant/{restaurantId}
    Retrieves details of a specific restaurant using its ID.

    GET /viewallrestaurants
    Retrieves a list of all restaurants.

This documentation outlines how to interact with the API, detailing the available endpoints and their functionalities.
