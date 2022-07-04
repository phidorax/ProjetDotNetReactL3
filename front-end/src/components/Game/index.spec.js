import { render, screen } from '@testing-library/react';
import MyComponent from './index';

test('renders learn react link', () => {
	render(<MyComponent name={"world"} />);
	const linkElement = screen.getByText(/Hello world/i);
	expect(linkElement).toBeInTheDocument();
});
