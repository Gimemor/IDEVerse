import {
  Directive,
  Input,
  TemplateRef,
  ViewContainerRef,
  OnInit,
  OnDestroy,
} from "@angular/core";
import { AuthenticationService } from "src/app/services/authentication.service";
import { Subscription } from "rxjs";
import { tap, filter } from "rxjs/operators";

@Directive({
  selector: "[appHasRight]",
})
export class HasRightDirective implements OnInit, OnDestroy {
  user$: Subscription;

  @Input()
  appHasRight: string;

  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef,
    private authService: AuthenticationService
  ) {}

  ngOnInit() {
    this.user$ = this.authService.currentUser
      .pipe(
        tap(() => this.viewContainer.clear()),
        filter(
          (user) =>
            !!user &&
            !!user.rights &&
            user.rights.findIndex((x) => x === this.appHasRight) > -1
        )
      )
      .subscribe(() => {
        this.viewContainer.createEmbeddedView(this.templateRef);
      });
  }

  ngOnDestroy() {
    this.user$.unsubscribe();
  }
}
