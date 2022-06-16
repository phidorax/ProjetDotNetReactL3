import useUserList from '../../hooks/useUserList';

import UserListView from './view';

export default function UserList(props) {
	return (
		<UserListView
			{...props}
			useUserList={useUserList}
		/>
	);
}