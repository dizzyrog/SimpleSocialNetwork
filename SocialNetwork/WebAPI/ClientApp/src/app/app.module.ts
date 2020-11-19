import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ProfileComponent } from './profile/profile.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ChatListComponent } from './chat/chat-list/chat-list.component';
import { FriendsListComponent } from './friend/friends-list/friends-list.component';
import { FriendSearchComponent } from './friend/friend-search/friend-search.component';
import { EditProfileComponent } from './profile/edit-profile/edit-profile.component';
import { RegistrationComponent } from './user/auth/registration/registration.component';
import { LoginComponent } from './user/auth/login/login.component';
import { HomeComponent } from './home/home.component';
import { ForbiddenComponent } from './user/auth/forbidden/forbidden.component';
import { UserService } from './user/user.service';
import { AuthInterceptor } from './user/auth/auth.interceptor';
import { AuthGuard } from './user/auth/auth.guard';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProfileComponent,
    CounterComponent,
    FetchDataComponent,
    ChatListComponent,
    FriendsListComponent,
    FriendSearchComponent,
    EditProfileComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    ForbiddenComponent,
    AdminPanelComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    RouterModule.forRoot([
      { path: '', component: ProfileComponent, pathMatch: 'full', canActivate:[AuthGuard] },
      {path: 'profile', component: EditProfileComponent},
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate:[AuthGuard],data :{permittedRoles:['Admin']} },
      { path: 'chats', component:  ChatListComponent},
      { path: 'friends', component: FriendsListComponent},
      { path: 'search', component: FriendSearchComponent},
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent},
      {path:'forbidden',component:ForbiddenComponent},
      {path:'admin',component:AdminPanelComponent}
    ])
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  },
  ToastrService
],

  bootstrap: [AppComponent]
})
export class AppModule { }
