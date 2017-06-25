import { Input, Component } from '@angular/core';
import { Record } from '../types';

@Component({
    selector: 'record',
    templateUrl: './record.component.html',
    styleUrls: ['./record.component.css']
})
export class RecordComponent {
    @Input() record: Record;
    public hideInfo: boolean = true;

    toggleInfo() {
        this.hideInfo = !this.hideInfo;
    }
}