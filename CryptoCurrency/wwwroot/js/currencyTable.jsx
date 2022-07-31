class AccountProfileList extends React.Component {
    render() {
        const accountProfileNodes = this.props.data.map(accountProfile => (
            <AccountProfile firstName={accountProfile.firstName} key={accountProfile.id}>
                {accountProfile.lastName}
            </AccountProfile>
        ));
        return <div className="accountProfileList">{accountProfileNodes}</div>;
    }
}
function createRemarkable() {
    var remarkable =
        'undefined' != typeof global && global.Remarkable
            ? global.Remarkable
            : window.Remarkable;

    return new remarkable();
}

class AccountProfile extends React.Component {
    rawMarkup() {
        const md = new createRemarkable();
        const rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup };
    }
    render() {
        return (
            <div className="accountProfile">
                <h2 className="accountProfileFirstName">{this.props.firstName}</h2>
                <span dangerouslySetInnerHTML={this.rawMarkup()} />
            </div>
        );
    }
}

class AccountProfileForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { firstName: '', lastName: '' };
        this.handleFirstNameChange = this.handleFirstNameChange.bind(this);
        this.handleLastNameChange = this.handleLastNameChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleFirstNameChange(e) {
        this.setState({ firstName: e.target.value });
    }
    handleLastNameChange(e) {
        this.setState({ lastName: e.target.value });
    }
    handleSubmit(e) {
        e.preventDefault();
        const firstName = this.state.firstName.trim();
        const lastName = this.state.lastName.trim();
        if (!lastName || !firstName) {
            return;
        }
        this.props.onAccountProfileSubmit({ firstName: firstName, lastName: lastName });
        this.setState({ firstName: '', lastName: '' });
    }
    render() {
        return (
            <form className="accountProfileForm" onSubmit={this.handleSubmit}>
                <input
                    type="text"
                    placeholder="Your name"
                    value={this.state.firstName}
                    onChange={this.handleFirstNameChange}
                />
                <input
                    type="text"
                    placeholder="LastName"
                    value={this.state.lastName}
                    onChange={this.handleLastNameChange}
                />
                <input type="submit" value="Post" />
            </form>
        );
    }
}

class AccountProfileBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
        this.handleAccountProfileSubmit = this.handleAccountProfileSubmit.bind(this);
    }
    loadAccountProfileFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }
    handleAccountProfileSubmit(accountProfile) {
        const data = new FormData();
        data.append('FirstName', accountProfile.firstName);
        data.append('LastName', accountProfile.lastName);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = () => this.loadAccountProfileFromServer();
        xhr.send(data);
    }
    componentDidMount() {
        this.loadAccountProfileFromServer();
        window.setInterval(
            () => this.loadAccountProfileFromServer(),
            this.props.pollInterval,
        );
    }
    render() {
        return (
            <div className="accountProfileBox">
                <h1>AccountProfile</h1>
                <AccountProfileList data={this.state.data} />
                <AccountProfileForm onAccountProfileSubmit={this.handleAccountProfileSubmit} />
            </div>
        );
    }
}

ReactDOM.render(
    <AccountProfileBox
        url="/accountProfile"
        submitUrl="/accountProfile/new"
        pollInterval={2000}
    />,
    document.getElementById('content'),
);

//ReactDOM.render(
//    <CommentBox url="/comments" />,
//    document.getElementById('content')
//);