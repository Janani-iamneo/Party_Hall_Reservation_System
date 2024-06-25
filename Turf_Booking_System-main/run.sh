#!/bin/bash  
if [ ! -d "/home/coder/project/workspace/dotnetapp/" ]
then
    cp -r /home/coder/project/workspace/nunit/dotnetapp /home/coder/project/workspace/;
fi
if [ -d "/home/coder/project/workspace/dotnetapp/" ]
then
    echo "project folder present"
    # checking for src folder
    if [ -d "/home/coder/project/workspace/dotnetapp/" ]
    then
        cp -r /home/coder/project/workspace/nunit/test/TestProject /home/coder/project/workspace/dotnetapp/;
        cp -r /home/coder/project/workspace/nunit/test/dotnetapp.sln /home/coder/project/workspace/dotnetapp/;
        cp /home/coder/project/workspace/puppeteer/package.json /home/coder/project/workspace/;
        cd /home/coder/project/workspace || exit;
        npm install;
        rm -rf /home/coder/project/workspace/node_modules/;
        rm -rf /home/coder/project/workspace/package.json;
        rm -rf /home/coder/project/workspace/package-lock.json;
        cd /home/coder/project/workspace/dotnetapp/TestProject || exit;
        dotnet clean;
        dotnet build && dotnet test -l "console;verbosity=normal";
    else
        echo "BookingController_Get_Book_by_partyHallId_ReturnsViewResult FAILED";
        echo "BookingController_Get_Book_by_InvalidPartyHallId_ReturnsNotFound FAILED";
        echo "BookingController_Post_Book_ValidBooking_Success_Redirects_Details FAILED";
        echo "BookingController_Post_Book_by_InvalidPartyHallId_ReturnsNotFound FAILED";
        echo "PartyHallController_Delete_ValidPartyHallId_Success_Redirects_Delete FAILED";
        echo "PartyHallController_DeleteConfirmed_ValidPartyHallId_RedirectsTo_Index FAILED";
        echo "PartyHallController_Delete_InvalidPartyHallId_NotFound FAILED";
        echo "PartyHallController_Index_ReturnsViewWithPartyHallList FAILED";
        echo "BookingController_Post_Book_by_InvalidDurationInMinutes_ThrowsException FAILED";
        echo "Booking_Properties_CustomerName_ContactNumber_DurationInMinutes_HaveCorrectDataTypes FAILED";
        echo "PartyHallClassExists FAILED";
        echo "BookingClassExists FAILED";
        echo "ApplicationDbContextContainsDbSetBookingProperty FAILED";
        echo "ApplicationDbContextContainsDbSetPartyHallProperty FAILED";
        echo "PartyHall_Properties_GetSetCorrectly FAILED";
        echo "PartyHall_Properties_Availability_GetSetCorrectly FAILED";
        echo "PartyHall_Properties_HaveCorrectDataTypes FAILED";
        echo "Search_Matches_Exactly_ReturnsMatchingPartyHall FAILED";
    fi
else
    echo "BookSeat_Post_method_TrainController_ValidPassenger_BookedSuccessfully_Redirect_to_Details FAILED";
    echo "BookSeat_Post_method_TrainController_ValidPassenger_Adds_Passenger_To_Train_Successfully FAILED";
    echo "BookSeat_Post_method_TrainController_InvalidPassenger_Name_Email_Phone_are_required_ModelStateInvalid FAILED";
    echo "BookSeat_Get_method_TrainController_trainNotFound_ReturnsNotFoundResult FAILED";
    echo "TrainController_Delete_Method_ValidId_DeletesTrainSuccessfully_Redirects_AvailableTrains FAILED";
    echo "TrainBookingException_ClassExists FAILED";
    echo "BookSeat_Get_method_Throws_Exceptions_With_Message_Maximum_capacity_reached FAILED";
    echo "ApplicationDbContext_ContainsDbSet_Train FAILED";
    echo "ApplicationDbContext_ContainsDbSet_Passenger FAILED";
    echo "Passenger_ClassExists FAILED";
    echo "Train_ClassExists FAILED";
    echo "Passenger_PassengerID_PropertyExists_ReturnExpectedDataTypes_int FAILED";
    echo "Passenger_Name_PropertyExists_ReturnExpectedDataTypes_string FAILED";
    echo "Passenger_Email_PropertyExists_ReturnExpectedDataTypes_string FAILED";
    echo "Passenger_Phone_PropertyExists_ReturnExpectedDataTypes_string FAILED";
    echo "Passenger_trainID_PropertyExists_ReturnExpectedDataTypes_int FAILED";
    echo "Train_TrainID_PropertyExists_ReturnExpectedDataTypes_int FAILED";
    echo "Train_DepartureLocation_PropertyExists_ReturnExpectedDataTypes_string FAILED";
    echo "Train_Destination_PropertyExists_ReturnExpectedDataTypes_string FAILED";
    echo "Train_DepartureTime_PropertyExists_ReturnExpectedDataTypes_DateTime FAILED";
    echo "Train_MaximumCapacity_PropertyExists_ReturnExpectedDataTypes_int FAILED";
    echo "Details_Get_method_PassengerController_ReturnsNotFoundResult FAILED";
    echo "DeleteConfirm_Get_method_TrainController_ReturnsNotFoundResult FAILED";
    echo "AvailableTrains_Get_method_TrainController_ReturnsViewResult FAILED";
    echo "DeleteConfirm_Get_method_PassengerController_ReturnsViewResult_WithValidModel FAILED";
fi
