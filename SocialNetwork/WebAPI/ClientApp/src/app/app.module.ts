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
    EditProfileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ProfileComponent, pathMatch: 'full' },
      {path: 'profile', component: EditProfileComponent},
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'chats', component:  ChatListComponent},
      { path: 'friends', component: FriendsListComponent},
      { path: 'search', component: FriendSearchComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
