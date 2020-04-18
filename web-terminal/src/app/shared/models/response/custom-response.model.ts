import { CustomNotificationResponse } from './custom-notification-response.model';

export class CustomResponse<T>{
    data: T;
    message: string;
    notifications: CustomNotificationResponse[];
}