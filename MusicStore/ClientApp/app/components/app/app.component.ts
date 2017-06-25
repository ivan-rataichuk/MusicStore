import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/auth.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [AuthenticationService]
})
export class AppComponent {
}
