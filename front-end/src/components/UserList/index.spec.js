import { render, screen } from '@testing-library/react';
import View from './view';

test('renders error', () => {
	const useUserList = () => {
		return {
			isLoading: false,
			error: 'Ca marche pas',
			userList: []
		};
	};

	render(<View useUserList={useUserList} />);
	const errorElement = screen.getByText(/Ca marche pas/i);
	expect(errorElement).toBeInTheDocument();
});
