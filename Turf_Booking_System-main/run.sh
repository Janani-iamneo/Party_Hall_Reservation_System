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
        echo "BookingController_Post_Book_ThrowsException_with_message FAILED";
        echo "BookingController_Details_by_InvalidBookingId_ReturnsNotFound FAILED";
        echo "Booking_Properties_BookingID_GetSetCorrectly FAILED";
        echo "Booking_Properties_PartyHallID_GetSetCorrectly FAILED";
        echo "Booking_Properties_DurationInMinutes_GetSetCorrectly FAILED";
        echo "Booking_Properties_BookingID_HaveCorrectDataTypes FAILED";
        echo "Booking_Properties_PartyHallID_HaveCorrectDataTypes FAILED";
        echo "Booking_Properties_CustomerName_ContactNumber_DurationInMinutes_HaveCorrectDataTypes FAILED";
        echo "PartyHallClassExists FAILED";
        echo "BookingClassExists FAILED";
        echo "ApplicationDbContextContainsDbSetBookingProperty FAILED";
        echo "ApplicationDbContextContainsDbSetPartyHallProperty FAILED";
        echo "PartyHall_Properties_GetSetCorrectly FAILED";
        echo "PartyHall_Properties_Capacity_GetSetCorrectly FAILED";
        echo "PartyHall_Properties_Availability_GetSetCorrectly FAILED";
        echo "PartyHall_Properties_HaveCorrectDataTypes FAILED";
        echo "Search_Matches_Exactly_ReturnsMatchingPartyHall FAILED";
    fi
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
    echo "BookingController_Post_Book_ThrowsException_with_message FAILED";
    echo "BookingController_Details_by_InvalidBookingId_ReturnsNotFound FAILED";
    echo "Booking_Properties_BookingID_GetSetCorrectly FAILED";
    echo "Booking_Properties_PartyHallID_GetSetCorrectly FAILED";
    echo "Booking_Properties_DurationInMinutes_GetSetCorrectly FAILED";
    echo "Booking_Properties_BookingID_HaveCorrectDataTypes FAILED";
    echo "Booking_Properties_PartyHallID_HaveCorrectDataTypes FAILED";
    echo "Booking_Properties_CustomerName_ContactNumber_DurationInMinutes_HaveCorrectDataTypes FAILED";
    echo "PartyHallClassExists FAILED";
    echo "BookingClassExists FAILED";
    echo "ApplicationDbContextContainsDbSetBookingProperty FAILED";
    echo "ApplicationDbContextContainsDbSetPartyHallProperty FAILED";
    echo "PartyHall_Properties_GetSetCorrectly FAILED";
    echo "PartyHall_Properties_Capacity_GetSetCorrectly FAILED";
    echo "PartyHall_Properties_Availability_GetSetCorrectly FAILED";
    echo "PartyHall_Properties_HaveCorrectDataTypes FAILED";
    echo "Search_Matches_Exactly_ReturnsMatchingPartyHall FAILED";
fi
