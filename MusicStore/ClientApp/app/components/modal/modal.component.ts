import { Input, Component } from '@angular/core';
import { Record } from '../types';

@Component({
    selector: 'modal',
    templateUrl: './modal.component.html',
    styleUrls: ['./modal.component.css']
})
export class ModalComponent {
    @Input() record: Record;

    public visible = false;
    private visibleAnimate = false;

    constructor() { }

    public show() {
        this.visible = true;
        setTimeout(() => this.visibleAnimate = true, 100);
    }

    public hide() {
        this.visibleAnimate = false;
        setTimeout(() => this.visible = false, 300);
    }

    public onContainerClicked(event: MouseEvent) {
        if ((<HTMLElement>event.target).classList.contains('modal')) {
            this.hide();
        }
    }

}